using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class Parent : Person, IEntity
    {
        public IList<ParentLanguage> ParentLanguages { get; set; }
        public IList<ParentHobby> ParentHobbys { get; set; }
    }
}
