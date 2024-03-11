using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ChildSchoolSubjectRepository : IChildSchoolSubjectRepository
    {
        private readonly ParentsAbroadDbContext _context;

        public ChildSchoolSubjectRepository(ParentsAbroadDbContext context)
        {
            _context = context;
        }

        public async Task<ChildSchoolSubject> GetAsync(int childId, int schoolSubjectId)
        {
            return await _context.ChildSchoolSubjects.FirstOrDefaultAsync(x => x.ChildId == childId && x.SchoolSubjectId == schoolSubjectId);
        }

        public async Task<bool> AddSchoolSubjectAsync(ChildSchoolSubject entity)
        {
            if (entity != null)
            {
                _context.ChildSchoolSubjects.Add(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can't add this school subject");
            }

            return true;
        }

        public async Task<bool> DeleteSchoolSubjectAsync(ChildSchoolSubject entity)
        {
            if (entity == null)
            {
                throw new Exception("Can't delete this school subject");
            }

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
