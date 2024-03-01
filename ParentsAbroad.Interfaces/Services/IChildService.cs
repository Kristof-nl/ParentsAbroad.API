using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Models.Models;
using ParentsAbroad.Shared.Dto;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IChildService
    {
        Task<ChildDto> GetByAsync(Expression<Func<Child, bool>> filter);
        Task<ChildDto> GetByIdAsync(long id);
        Task<IList<ChildDto>> GetAllAsync();
        Task<IList<ChildDto>> GetAllChildrenFromFamilyAsync(long familyId);
        Task<ResponseResult<ChildDto>> AddAsync(ChildCreateUpdateDto child);
        Task<ChildDto> UpdateAsync(ChildCreateUpdateDto child);
        Task<bool> DeleteAsync(long id);
    }
}
