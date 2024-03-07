using ParentsAbroad.Models.Models;
using System;
namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IChildLikeToDoRepository
    {
        Task<bool> AddLikeToDoThingAsync(ChildLikeToDo entity);
        Task<ChildLikeToDo> GetAsync(long childId, long likeToDoId);
        Task<bool> DeleteLikeToDoThingAsync(ChildLikeToDo entity);
    }
}
