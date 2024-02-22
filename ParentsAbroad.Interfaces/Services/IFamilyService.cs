using ParentsAbroad.Contracts;
using ParentsAbroad.Models.Models;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IFamilyService
    {
        Task<FamilyDto> GetByAsync(Expression<Func<Family, bool>> filter);
        Task<FamilyDto> GetByIdAsync(long id);
        Task<IList<FamilyDto>> GetAllAsync();
        Task<FamilyDto> AddAsync(FamilyCreateUpdateDto family);
        Task<FamilyDto> UpdateAsync(FamilyCreateUpdateDto family);
        Task<bool> DeleteAsync(long id);
    }
}
