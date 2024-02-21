using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class FamilyRepository : BaseRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(ParentsAbroadDbContext context) : base(context)
        {
        }
    }
}
