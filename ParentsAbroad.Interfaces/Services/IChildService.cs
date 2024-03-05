using ParentsAbroad.Contracts;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IChildService
    {
        Task<ChildDto> GetByAsync(Expression<Func<Child, bool>> filter);
        Task<ChildDto> GetByIdAsync(long id, bool withRelations);
        Task<IList<ChildDto>> GetAllAsync(bool withRelations);
        Task<IList<ChildDto>> GetAllChildrenFromFamilyAsync(long familyId);
        Task<ResponseResult<ChildDto>> AddAsync(ChildCreateUpdateDto child);
        Task<ChildDto> UpdateAsync(ChildCreateUpdateDto child);
        Task<bool> DeleteAsync(long id);
        Task<ResponseResult<bool>> AddLanguageAsync(AddLanguageDto addLanguageDto);
        Task<bool> DeleteLanguageAsync(long childId, long languageId);
        Task<ResponseResult<bool>> AddSchoolSubjectAsync(AddSchoolSubjectDto addSchoolSubjectDto);
        Task<bool> DeleteSchoolSubjectAsync(long childId, long schoolSubjectId);
    }
}
