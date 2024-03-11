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
        Task<ParentDto> GetByIdAsync(int id, bool withRelations);
        Task<IList<ParentDto>> GetAllAsync(bool withRelations);
        Task<IList<ParentDto>> GetAllParentsFromFamilyAsync(int familyId);
        Task<ResponseResult<ParentDto>> AddAsync(ParentCreateUpdateDto parent);
        Task<ParentDto> UpdateAsync(ParentCreateUpdateDto parent);
        Task<bool> DeleteAsync(int id);
        Task<ResponseResult<bool>> AddLanguageAsync(AddLanguageDto addLanguageDto);
        Task<bool> DeleteLanguageAsync(int parentId, int languageId);
        Task<ResponseResult<bool>> AddHobbyAsync(AddHobbyDto addHobbyDto);
        Task<bool> DeleteHobbyAsync(int parentId, int hobbyId);
    }
}
