using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IParentHobbyRepository
    {
        Task<bool> AddHobbyAsync(ParentHobby entity);
        Task<ParentHobby> GetAsync(long parentId, long languageId);
        Task<bool> DeleteHobbyAsync(ParentHobby entity);
    }
}
