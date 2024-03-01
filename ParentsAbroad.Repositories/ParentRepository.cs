using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ParentRepository : BaseRepository<Parent>, IParentRepository
    {
        private readonly ParentsAbroadDbContext _context;
        public ParentRepository(ParentsAbroadDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Parent> GetParentWithRelationsAsync(long parentId)
        {
            return await _context.Parents.Include(f => f.Family).Include(l => l.ParentLanguages).ThenInclude(x => x.Language).FirstOrDefaultAsync(x => x.Id == parentId);
        }
    }
}
