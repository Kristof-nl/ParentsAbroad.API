using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IParentLanguageRepository
    {
        Task<bool> AddLanguageAsync(ParentLanguage entity);
    }
}
