using ParentsAbroad.Contracts;
using ParentsAbroad.Models.Models;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IParentService
    {
        Task<ParentDto> GetByAsync(Expression<Func<Parent, bool>> filter);
        Task<ParentDto> GetByIdAsync(long id);
        Task<IList<ParentDto>> GetAllAsync();
        Task<IList<ParentDto>> GetAllParentsFromFamilyAsync(long familyId);
        Task<ParentDto> AddAsync(ParentCreateUpdateDto parent);
        Task<ParentDto> UpdateAsync(ParentCreateUpdateDto parent);
        Task<bool> DeleteAsync(long id);
    }
}
