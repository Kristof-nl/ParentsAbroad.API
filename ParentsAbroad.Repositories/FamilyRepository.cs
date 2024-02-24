using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class FamilyRepository : BaseRepository<Family>, IFamilyRepository
    {
        private readonly ParentsAbroadDbContext _context;

        public FamilyRepository(ParentsAbroadDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Family>> GetFamiliesWithRelationsAsync()
        {
            return await _context.Families.Include(p => p.Parents).Include(c => c.Children).ToListAsync();
        }
    }
}
