using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ChildLanguageRepository : IChildLanguageRepository
    {
        private readonly ParentsAbroadDbContext _context;

        public ChildLanguageRepository(ParentsAbroadDbContext context)
        {
            _context = context;
        }

        public async Task<ChildLanguage> GetAsync(int childId, int languageId)
        {
            return await _context.ChildLanguages.FirstOrDefaultAsync(x => x.ChildId == childId && x.LanguageId == languageId);
        }

        public async Task<bool> AddLanguageAsync(ChildLanguage entity)
        {
            if (entity != null)
            {
                _context.ChildLanguages.Add(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can't add this language");
            }

            return true;
        }

        public async Task<bool> DeleteLanguageAsync(ChildLanguage entity)
        {
            if (entity == null)
            {
                throw new Exception("Can't delete this language");
            }

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
