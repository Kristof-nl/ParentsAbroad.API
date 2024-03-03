using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IParentRepository : IBaseRepository<Parent>
    {
        Task<Parent> GetParentWithRelationsAsync(long parentId);
        Task<IList<Parent>> GetAllParentsWithRelationsAsync();
    }
}
