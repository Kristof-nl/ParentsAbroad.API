namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetByAsync();
        Task<T> SaveOrUpdate(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
