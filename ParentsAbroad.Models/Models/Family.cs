using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class Family : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Child> Children { get; set; }
        public IList<Parent> Parents { get; set; }
    }
}
