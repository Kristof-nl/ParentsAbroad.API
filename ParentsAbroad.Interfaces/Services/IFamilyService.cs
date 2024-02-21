using ParentsAbroad.Models.Models;
using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Services
{
    public interface IFamilyService
    {
        Task<Family> GetByAsync(Expression<Func<Family, bool>> filter);
        Task<Family> GetByIdAsync(long id);
        Task<IList<Family>> GetAllAsync();
        Task<Family> SaveOrUpdateAsync(Family family);
        Task<bool> DeleteAsync(long id);
    }
}
