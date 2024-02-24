namespace ParentsAbroad.Contracts
{
    public class PersonCreateUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FamilyId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
