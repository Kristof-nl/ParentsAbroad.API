using ParentsAbroad.Contracts.Family;
using ParentsAbroad.Contracts.Person;

namespace ParentsAbroad.Contracts.Child
{
    public class ChildDto : PersonDto
    {
        public virtual FamilyDto Family { get; set; }
    }
}
