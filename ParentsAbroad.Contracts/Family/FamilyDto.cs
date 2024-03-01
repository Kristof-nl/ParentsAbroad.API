using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Parent;

namespace ParentsAbroad.Contracts.Family
{
    public class FamilyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ChildDto> Children { get; set; }
        public IList<ParentDto> Parents { get; set; }
    }
}
