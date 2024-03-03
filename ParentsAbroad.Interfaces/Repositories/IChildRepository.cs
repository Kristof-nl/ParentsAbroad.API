using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IChildRepository : IBaseRepository<Child>
    {
        Task<Child> GetByIdWithRelationsAsync(long parentId);
        Task<IList<Child>> GetAllChildrenWithRelationsAsync();
    }
}
