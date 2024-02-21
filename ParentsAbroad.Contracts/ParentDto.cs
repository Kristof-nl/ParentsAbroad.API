using System.ComponentModel.DataAnnotations;

namespace ParentsAbroad.Contracts
{
    public class ParentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual FamilyDto Family { get; set; }
    }
}
