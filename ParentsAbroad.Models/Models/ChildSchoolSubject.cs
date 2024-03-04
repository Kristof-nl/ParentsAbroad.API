namespace ParentsAbroad.Models.Models
{
    public class ChildSchoolSubject
    {
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int SchoolSubjectId { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
