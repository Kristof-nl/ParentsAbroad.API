using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ParentHobbyRepository : IParentHobbyRepository
    {
        private readonly ParentsAbroadDbContext _context;

        public ParentHobbyRepository(ParentsAbroadDbContext context)
        {
            _context = context;
        }

        public async Task<ParentHobby> GetAsync(long parentId, long hobbyId)
        {
            return await _context.ParentHobby.FirstOrDefaultAsync(x => x.ParentId == parentId && x.HobbyId == hobbyId);
        }

        public async Task<bool> AddHobbyAsync(ParentHobby entity)
        {
            if (entity != null)
            {
                _context.ParentHobby.Add(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can't add this hobby");
            }

            return true;
        }

        public async Task<bool> DeleteHobbyAsync(ParentHobby entity)
        {
            if (entity == null)
            {
                throw new Exception("Can't delete this hobby");
            }

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
