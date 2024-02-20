﻿using System.Linq.Expressions;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetByAsync(Expression<Func<T, bool>> filter);
        Task<T> SaveOrUpdate(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
