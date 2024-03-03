using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ParentLanguageRepository :  IParentLanguageRepository
    {
        private readonly ParentsAbroadDbContext _context;

        public ParentLanguageRepository(ParentsAbroadDbContext context)
        {
            _context = context;
        }

        public async Task<ParentLanguage> GetAsync(long parentId, long languageId)
        {
            return await _context.ParentLanguages.FirstOrDefaultAsync(x => x.ParentId == parentId && x.LanguageId == languageId);
        }

        public async Task<bool> AddLanguageAsync(ParentLanguage entity)
        {
            if (entity != null) 
            {
                _context.ParentLanguages.Add(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can't add this language");
            }

            return true;
        }

        public async Task<bool> DeleteLanguageAsync(ParentLanguage entity)
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
