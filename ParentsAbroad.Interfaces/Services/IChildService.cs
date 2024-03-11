using ParentsAbroad.Contracts;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.LikeToDo;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IChildService
    {
        Task<ChildDto> GetByAsync(Expression<Func<Child, bool>> filter);
        Task<ChildDto> GetByIdAsync(int id, bool withRelations);
        Task<IList<ChildDto>> GetAllAsync(bool withRelations);
        Task<IList<ChildDto>> GetAllChildrenFromFamilyAsync(int familyId);
        Task<ResponseResult<ChildDto>> AddAsync(ChildCreateUpdateDto child);
        Task<ChildDto> UpdateAsync(ChildCreateUpdateDto child);
        Task<bool> DeleteAsync(int id);
        Task<ResponseResult<bool>> AddLanguageAsync(AddLanguageDto addLanguageDto);
        Task<bool> DeleteLanguageAsync(int childId, int languageId);
        Task<ResponseResult<bool>> AddSchoolSubjectAsync(AddSchoolSubjectDto addSchoolSubjectDto);
        Task<bool> DeleteSchoolSubjectAsync(int childId, int schoolSubjectId);
        Task<ResponseResult<bool>> AddLikeToDoThingAsync(LikeToDoAddDto likeToDoAddDto);
        Task<bool> DeleteLikeToDoThingAsync(int childId, int likeToDoId);
    }
}
