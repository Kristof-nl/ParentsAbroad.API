using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models.Interfaces;
using System.Linq.Expressions;

namespace ParentsAbroad.Repositories

{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly ParentsAbroadDbContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository(ParentsAbroadDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> SaveOrUpdateAsync(T entity)
        {
            if (entity.Id == 0)
            {
                _dbSet.Add(entity);
            }
            else
            {
                var existingEntity = _dbSet.FirstOrDefault(x => x.Id == entity.Id);

                if (existingEntity == null)
                {
                    throw new Exception($"Entity with id:{entity.Id} not found");
                }

                _dbSet.Entry(existingEntity).CurrentValues.SetValues(entity);
                
            }

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existingEntity = _dbSet.FirstOrDefault(x => x.Id == id);

            if (existingEntity == null)
            {
                throw new Exception($"Entity with id:{id} not found");
            }

            _dbSet.Remove(existingEntity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<T>> GetByAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
