using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IParentLanguageRepository
    {
        Task<bool> AddLanguageAsync(ParentLanguage entity);
        Task<ParentLanguage> GetAsync(int parentId, int languageId);
        Task<bool> DeleteLanguageAsync(ParentLanguage entity);
    }
}
