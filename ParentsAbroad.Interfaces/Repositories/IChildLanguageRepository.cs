using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IChildLanguageRepository
    {
        Task<bool> AddLanguageAsync(ChildLanguage entity);
        Task<ChildLanguage> GetAsync(long childId, long languageId);
        Task<bool> DeleteLanguageAsync(ChildLanguage entity);
    }
}
