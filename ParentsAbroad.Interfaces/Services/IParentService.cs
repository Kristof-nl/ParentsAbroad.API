using ParentsAbroad.Contracts.Hobby;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.Parent;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IParentService
    {
        Task<ParentDto> GetByAsync(Expression<Func<Parent, bool>> filter);
        Task<ParentDto> GetByIdAsync(long id, bool withRelations);
        Task<IList<ParentDto>> GetAllAsync(bool withRelations);
        Task<IList<ParentDto>> GetAllParentsFromFamilyAsync(long familyId);
        Task<ResponseResult<ParentDto>> AddAsync(ParentCreateUpdateDto parent);
        Task<ParentDto> UpdateAsync(ParentCreateUpdateDto parent);
        Task<bool> DeleteAsync(long id);
        Task<ResponseResult<bool>> AddLanguageAsync(AddLanguageDto addLanguageDto);
        Task<bool> DeleteLanguageAsync(long parentId, long languageId);
        Task<ResponseResult<bool>> AddHobbyAsync(AddHobbyDto addHobbyDto);
        Task<bool> DeleteHobbyAsync(long parentId, long hobbyId);
    }
}
