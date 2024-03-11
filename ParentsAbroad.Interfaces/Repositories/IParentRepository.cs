using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IParentRepository : IBaseRepository<Parent>
    {
        Task<Parent> GetParentWithRelationsAsync(int parentId);
        Task<IList<Parent>> GetAllParentsWithRelationsAsync();
    }
}
