namespace ParentsAbroad.Contracts
{
    public class ChildDto : PersonDto
    {
        public virtual FamilyDto Family { get; set; }
    }
}
