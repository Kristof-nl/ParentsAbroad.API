namespace ParentsAbroad.Contracts.Person
{
    public class PersonCreateUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FamilyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual IList<LanguageDto> Languages { get; set; }
    }
}
