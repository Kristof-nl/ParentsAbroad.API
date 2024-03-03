using AutoMapper;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using ParentsAbroad.Shared.Enums;
using ParentsAbroad.Shared.Helpers;
using System.Linq.Expressions;

namespace ParentsAbroad.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IChildLanguageRepository _childLanguageRepository;
        private readonly IMapper _mapper;

        public ChildService(IChildRepository childRepository,
            IChildLanguageRepository childLanguageRepository,
            IMapper mapper)
        {
            _childRepository = childRepository;
            _childLanguageRepository = childLanguageRepository;
            _mapper = mapper;
        }


        public async Task<IList<ChildDto>> GetAllChildrenFromFamilyAsync(long familyId)
        {
            var children = await _childRepository.GetByAsync(x => x.FamilyId == familyId);
            return _mapper.Map<IList<ChildDto>>(children);
        }

        public async Task<IList<ChildDto>> GetAllAsync()
        {
            var children = await _childRepository.GetAllAsync();
            return _mapper.Map<IList<ChildDto>>(children);
        }

        public async Task<ChildDto> GetByAsync(Expression<Func<Child, bool>> filter)
        {
            var parent = await _childRepository.GetByAsync(filter);
            return _mapper.Map<ChildDto>(parent);
        }

        public async Task<ChildDto> GetByIdAsync(long id, bool withRelations)
        {
            var child = withRelations ? await _childRepository.GetByIdWithRelationsAsync(id) : await _childRepository.GetByIdAsync(id);

            if (child == null)
            {
                throw new Exception($"Child with id: {id} not found");
            }

            return _mapper.Map<ChildDto>(child);
        }


        public async Task<ResponseResult<ChildDto>> AddAsync(ChildCreateUpdateDto childCreateDto)
        {
            if (childCreateDto.Id > 0)
            {
                throw new Exception("This item can't be added");
            }


            // Child need to be younger than 18 years old
            var childToOld = DateTimeHelper.GetDifferenceInYears(childCreateDto.DateOfBirth) > 17;

            if (childToOld)
            {
                return new ResponseResult<ChildDto>
                {
                    Message = "Child needs to be younger than 18 years old",
                    MessageServerity = ResponsResultServerity.warning.ToString()
                };
            }


            var child = _mapper.Map<Child>(childCreateDto);

            var childFromDb = await _childRepository.SaveOrUpdateAsync(child);

            var childDto = _mapper.Map<ChildDto>(childFromDb);

            return new ResponseResult<ChildDto>
            {
                ResponseObject = childDto
            };
        }

        public async Task<ChildDto> UpdateAsync(ChildCreateUpdateDto childUpdateDto)
        {
            if (childUpdateDto.Id == null || childUpdateDto.Id == 0)
            {
                throw new Exception("This item can't be updated");
            }

            var child = _mapper.Map<Child>(childUpdateDto);

            var childFromDb = await _childRepository.SaveOrUpdateAsync(child);

            return _mapper.Map<ChildDto>(childFromDb);
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var child = await _childRepository.GetByIdAsync(id);

            if (child == null)
            {
                throw new Exception($"Child with id: {id} not found");
            }
            else
            {
                return await _childRepository.DeleteAsync(id);
            }
        }

        public async Task<ResponseResult<bool>> AddLanguageAsync(AddLanguageDto addLanguageDto)
        {
            if (addLanguageDto.PersonId < 1 || addLanguageDto.LanguageId < 1)
            {
                throw new Exception("This item can't be added");
            }

            var entityFromDb = await _childLanguageRepository.GetAsync(addLanguageDto.PersonId, addLanguageDto.LanguageId);

            if (entityFromDb != null)
            {
                return new ResponseResult<bool>
                {
                    Message = "This language is already added",
                    MessageServerity = ResponsResultServerity.info.ToString()
                };
            }

            var newlanguageToAdd = new ChildLanguage()
            {
                ChildId = addLanguageDto.PersonId,
                LanguageId = addLanguageDto.LanguageId
            };

            return new ResponseResult<bool>
            {
                ResponseObject = await _childLanguageRepository.AddLanguageAsync(newlanguageToAdd)
            };
        }
    }
}
