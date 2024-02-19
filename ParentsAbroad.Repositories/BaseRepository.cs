using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using System.Linq.Expressions;

namespace ParentsAbroad.Repositories

{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ParentsAbroadDbContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository(ParentsAbroadDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> SaveOrUpdate(T entity, int id)
        {
            if (id == 0) 
            { 
                _dbSet.Add(entity);
            }
            else
            {
                var existingEntity = _dbSet.FirstOrDefault(x => x. == id);

                if (existingEntity != null)
                {
                    _dbSet.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
            }

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingEntity = _dbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (existingEntity != null) 
            {
                _dbSet.Remove(existingEntity);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<T>> GetByAsync(Expression<Func<T, bool>> filter )
        {
            return await _dbSet.Where(filter).ToListAsync();
        }
    }
}
