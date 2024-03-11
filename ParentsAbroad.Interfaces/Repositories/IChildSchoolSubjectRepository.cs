using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Interfaces.Repositories
{
    public interface IChildSchoolSubjectRepository
    {
        Task<bool> AddSchoolSubjectAsync(ChildSchoolSubject entity);
        Task<ChildSchoolSubject> GetAsync(int childId, int schoolSubjectId);
        Task<bool> DeleteSchoolSubjectAsync(ChildSchoolSubject entity);
    }
}
