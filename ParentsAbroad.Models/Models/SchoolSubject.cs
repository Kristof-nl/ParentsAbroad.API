using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class SchoolSubject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ChildSchoolSubject> ChildSchoolSubjects { get; set; }
    }
}
