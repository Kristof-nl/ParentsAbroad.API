﻿using AutoMapper;
using ParentsAbroad.Contracts;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.LikeToDo;
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
        private readonly IChildSchoolSubjectRepository _childSchoolSubjectRepository;
        private readonly IChildLikeToDoRepository _childLikeToDoRepository;
        private readonly IMapper _mapper;

        public ChildService(IChildRepository childRepository,
            IChildLanguageRepository childLanguageRepository,
            IChildSchoolSubjectRepository childSchoolSubjectRepository,
            IChildLikeToDoRepository childLikeToDoRepository,
            IMapper mapper)
        {
            _childRepository = childRepository;
            _childLanguageRepository = childLanguageRepository;
            _childSchoolSubjectRepository = childSchoolSubjectRepository;
            _childLikeToDoRepository = childLikeToDoRepository;
            _mapper = mapper;
        }


        public async Task<IList<ChildDto>> GetAllChildrenFromFamilyAsync(int familyId)
        {
            var children = await _childRepository.GetByAsync(x => x.FamilyId == familyId);
            return _mapper.Map<IList<ChildDto>>(children);
        }

        public async Task<IList<ChildDto>> GetAllAsync(bool withRelations)
        {
            var children = withRelations ? await _childRepository.GetAllChildrenWithRelationsAsync() : await _childRepository.GetAllAsync();
            return _mapper.Map<IList<ChildDto>>(children);
        }

        public async Task<ChildDto> GetByAsync(Expression<Func<Child, bool>> filter)
        {
            var parent = await _childRepository.GetByAsync(filter);
            return _mapper.Map<ChildDto>(parent);
        }

        public async Task<ChildDto> GetByIdAsync(int id, bool withRelations)
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


        public async Task<bool> DeleteAsync(int id)
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

        public async Task<bool> DeleteLanguageAsync(int childId, int languageId)
        {
            var entity = await _childLanguageRepository.GetAsync(childId, languageId);

            if (entity == null)
            {
                throw new Exception($"Can't find language with id: {languageId} for child with id: {childId}");
            }
            else
            {
                return await _childLanguageRepository.DeleteLanguageAsync(entity);
            }
        }

        public async Task<ResponseResult<bool>> AddSchoolSubjectAsync(AddSchoolSubjectDto addSchoolSubjectDto)
        {
            if (addSchoolSubjectDto.ChildId < 1 || addSchoolSubjectDto.SchoolSubjectId < 1)
            {
                throw new Exception("This item can't be added");
            }

            var entityFromDb = await _childSchoolSubjectRepository.GetAsync(addSchoolSubjectDto.ChildId, addSchoolSubjectDto.SchoolSubjectId);

            if (entityFromDb != null)
            {
                return new ResponseResult<bool>
                {
                    Message = "This school subject is already added",
                    MessageServerity = ResponsResultServerity.info.ToString()
                };
            }

            var newlanguageToAdd = new ChildSchoolSubject()
            {
                ChildId = addSchoolSubjectDto.ChildId,
                SchoolSubjectId = addSchoolSubjectDto.SchoolSubjectId
            };

            return new ResponseResult<bool>
            {
                ResponseObject = await _childSchoolSubjectRepository.AddSchoolSubjectAsync(newlanguageToAdd)
            };
        }

        public async Task<bool> DeleteSchoolSubjectAsync(int childId, int schoolSubjectId)
        {
            var entity = await _childSchoolSubjectRepository.GetAsync(childId, schoolSubjectId);

            if (entity == null)
            {
                throw new Exception($"Can't find school subject with id: {schoolSubjectId} for child with id: {childId}");
            }
            else
            {
                return await _childSchoolSubjectRepository.DeleteSchoolSubjectAsync(entity);
            }
        }

        public async Task<ResponseResult<bool>> AddLikeToDoThingAsync(LikeToDoAddDto likeToDoAddDto)
        {
            if (likeToDoAddDto.ChildId < 1 || likeToDoAddDto.LikeToDoId < 1)
            {
                throw new Exception("This item can't be added");
            }

            var entityFromDb = await _childSchoolSubjectRepository.GetAsync(likeToDoAddDto.ChildId, likeToDoAddDto.LikeToDoId);

            if (entityFromDb != null)
            {
                return new ResponseResult<bool>
                {
                    Message = "This leisure activity is already added",
                    MessageServerity = ResponsResultServerity.info.ToString()
                };
            }

            var newLikeToDoAdd = new ChildLikeToDo()
            {
                ChildId = likeToDoAddDto.ChildId,
                LikeToDoId = likeToDoAddDto.LikeToDoId
            };

            return new ResponseResult<bool>
            {
                ResponseObject = await _childLikeToDoRepository.AddLikeToDoThingAsync(newLikeToDoAdd)
            };
        }

        public async Task<bool> DeleteLikeToDoThingAsync(int childId, int likeToDoId)
        {
            var entity = await _childLikeToDoRepository.GetAsync(childId, likeToDoId);

            if (entity == null)
            {
                throw new Exception($"Can't find leisure activity with id: {likeToDoId} for child with id: {childId}");
            }
            else
            {
                return await _childLikeToDoRepository.DeleteLikeToDoThingAsync(entity);
            }
        }
    }
}
