using AutoMapper;
using ParentsAbroad.Contracts;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using ParentsAbroad.Shared.Helpers;
using System.Linq.Expressions;
using ParentsAbroad.Shared.Enums;

namespace ParentsAbroad.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }


        public async Task<IList<ParentDto>> GetAllParentsFromFamilyAsync(long familyId)
        {
            var parents = await _parentRepository.GetByAsync(x => x.FamilyId == familyId);
            return _mapper.Map<IList<ParentDto>>(parents);
        }

        public async Task<IList<ParentDto>> GetAllAsync()
        {
            var parents = await _parentRepository.GetAllAsync();
            return _mapper.Map<IList<ParentDto>>(parents);
        }

        public async Task<ParentDto> GetByAsync(Expression<Func<Parent, bool>> filter)
        {
            var parent = await _parentRepository.GetByAsync(filter);
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<ParentDto> GetByIdAsync(long id, bool withRelations)
        {

            var parent = withRelations ? await _parentRepository.GetParentWithRelationsAsync(id) : await _parentRepository.GetByIdAsync(id);

            if (parent == null)
            {
                throw new Exception($"Parent with id: {id} not found");
            }

            return _mapper.Map<ParentDto>(parent);
        }


        public async Task<ResponseResult<ParentDto>> AddAsync(ParentCreateUpdateDto parentCreateDto)
        {
            if (parentCreateDto.Id > 0)
            {
                throw new Exception("This item can't be added");
            }

            if (GetAllParentsFromFamilyAsync(parentCreateDto.FamilyId).Result.Count == 2 ) 
            {
                return new ResponseResult<ParentDto> 
                {
                    Message = "There are already two parents added to this family. Is not possible to add more",
                    MessageServerity = ResponsResultServerity.warning.ToString()
                };
            }

            // Because of legal purpose parent need be at least 18 years old
            var parenToYoung = DateTimeHelper.GetDifferenceInYears(parentCreateDto.DateOfBirth) < 18;

            if (parenToYoung)
            {
                return new ResponseResult<ParentDto>
                {
                    Message = "You are to young to register as parent role",
                    MessageServerity = ResponsResultServerity.warning.ToString()
                };
            }


            var parent = _mapper.Map<Parent>(parentCreateDto);

            var parentFromDb = await _parentRepository.SaveOrUpdateAsync(parent);

            var parentDto = _mapper.Map<ParentDto>(parentFromDb);

            return new ResponseResult<ParentDto>
            {
                ResponseObject = parentDto
            };
        }

        public async Task<ParentDto> UpdateAsync(ParentCreateUpdateDto parentUpdateDto)
        {
            if (parentUpdateDto.Id == null || parentUpdateDto.Id == 0)
            {
                throw new Exception("This item can't be updated");
            }

            var parent = _mapper.Map<Parent>(parentUpdateDto);

            var parentFromDb = await _parentRepository.SaveOrUpdateAsync(parent);

            return _mapper.Map<ParentDto>(parentFromDb);
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);

            if (parent == null)
            {
                throw new Exception($"Parent with id: {id} not found");
            }
            else
            {
                return await _parentRepository.DeleteAsync(id);
            }
        }
    }
}
