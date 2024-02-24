using AutoMapper;
using ParentsAbroad.Contracts;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Helpers;
using System.Linq.Expressions;

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

        public async Task<ParentDto> GetByIdAsync(long id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);

            if (parent == null)
            {
                throw new Exception($"Parent with id: {id} not found");
            }

            return _mapper.Map<ParentDto>(parent);
        }


        public async Task<ParentDto> AddAsync(ParentCreateUpdateDto parentCreateDto)
        {
            if (parentCreateDto.Id > 0)
            {
                throw new Exception("This item can't be added");
            }

            if (GetAllParentsFromFamilyAsync(parentCreateDto.FamilyId).Result.Count == 2 ) 
            {
                throw new Exception("There are already two parents added to this family. In not possible to add more");
            }

            // Because of legal purpose parent need be at least 18 years old
            IsParentToYoung(parentCreateDto.DateOfBirth);


            var parent = _mapper.Map<Parent>(parentCreateDto);

            var parentFromDb = await _parentRepository.SaveOrUpdateAsync(parent);

            return _mapper.Map<ParentDto>(parentFromDb);
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

        private void IsParentToYoung(DateTime birthDate)
        {
           if (!DateTimeHelper.GetDifferenceInYears(birthDate))
           {
               throw new Exception($"You are to young to register as parent role");
           }
        }
    }
}
