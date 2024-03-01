using ParentsAbroad.Contracts.Family;

namespace ParentsAbroad.Contracts.Person
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ShortFamilyDto Family { get; set; }
    }
}
