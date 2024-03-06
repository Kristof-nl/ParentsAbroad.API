using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class Child : Person, IEntity
    {
        public IList<ChildLanguage> ChildLanguages { get; set; }
        public IList<ChildSchoolSubject> ChildSchoolSubjects { get; set; }
        public IList<ChildLikeToDo> ChildLikeToDoThings { get; set; }
    }
}
