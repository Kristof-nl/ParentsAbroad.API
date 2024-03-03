﻿using AutoMapper;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using ParentsAbroad.Shared.Helpers;
using System.Linq.Expressions;
using ParentsAbroad.Shared.Enums;
using ParentsAbroad.Contracts.Parent;
using ParentsAbroad.Contracts.Language;

namespace ParentsAbroad.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IParentLanguageRepository _parentLanguageRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository,
            IParentLanguageRepository parentLanguageRepository,
            IMapper mapper)
        {
            _parentRepository = parentRepository;
            _parentLanguageRepository = parentLanguageRepository;
            _mapper = mapper;
        }


        public async Task<IList<ParentDto>> GetAllParentsFromFamilyAsync(long familyId)
        {
            var parents = await _parentRepository.GetByAsync(x => x.FamilyId == familyId);
            return _mapper.Map<IList<ParentDto>>(parents);
        }

        public async Task<IList<ParentDto>> GetAllAsync(bool withRelations)
        {
            var parents = withRelations ? await _parentRepository.GetAllParentsWithRelationsAsync() : await _parentRepository.GetAllAsync();
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

        public async Task<ResponseResult<bool>> AddLanguageAsync(AddLanguageDto addLanguageDto)
        {
            if (addLanguageDto.PersonId < 1 || addLanguageDto.LanguageId < 1)
            {
                throw new Exception("This item can't be added");
            }

            var entityFromDb = await _parentLanguageRepository.GetAsync(addLanguageDto.PersonId, addLanguageDto.LanguageId);

            if (entityFromDb != null)
            {
                return new ResponseResult<bool>
                {
                    Message = "This language is already added",
                    MessageServerity = ResponsResultServerity.info.ToString()
                };
            }

            var newlanguageToAdd = new ParentLanguage()
            {
                ParentId = addLanguageDto.PersonId,
                LanguageId = addLanguageDto.LanguageId
            };


            return new ResponseResult<bool>
            {
                ResponseObject = await _parentLanguageRepository.AddLanguageAsync(newlanguageToAdd)
            };
        }
    }
}
