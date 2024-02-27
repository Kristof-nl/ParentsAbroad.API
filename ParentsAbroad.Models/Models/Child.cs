using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class Child : Person, IEntity
    {
        public IList<ChildLanguage> Languages { get; set; }
    }
}
