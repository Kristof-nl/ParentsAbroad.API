using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IChildLanguageRepository
    {
        Task<bool> AddLanguageAsync(ChildLanguage entity);
        Task<ChildLanguage> GetAsync(int childId, int languageId);
        Task<bool> DeleteLanguageAsync(ChildLanguage entity);
    }
}
