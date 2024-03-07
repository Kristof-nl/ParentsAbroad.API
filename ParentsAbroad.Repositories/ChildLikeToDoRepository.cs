using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ChildLikeToDoRepository : IChildLikeToDoRepository
    {
        private readonly ParentsAbroadDbContext _context;

        public ChildLikeToDoRepository(ParentsAbroadDbContext context)
        {
            _context = context;
        }

        public async Task<ChildLikeToDo> GetAsync(long childId, long likeToDoId)
        {
            return await _context.ChildLikeToDo.FirstOrDefaultAsync(x => x.ChildId == childId && x.LikeToDoId == likeToDoId);
        }

        public async Task<bool> AddLikeToDoThingAsync(ChildLikeToDo entity)
        {
            if (entity != null)
            {
                _context.ChildLikeToDo.Add(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can't add this leisure activity");
            }

            return true;
        }

        public async Task<bool> DeleteLikeToDoThingAsync(ChildLikeToDo entity)
        {
            if (entity == null)
            {
                throw new Exception("Can't delete this leisure activity");
            }

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
