using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IFamilyRepository : IBaseRepository<Family>
    {
        Task<IList<Family>> GetFamiliesWithRelationsAsync();
        Task<Family> GetFamilyWithRelationsAsync(long familyId);
    }
}
