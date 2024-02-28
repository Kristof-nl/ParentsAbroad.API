namespace ParentsAbroad.Models.Models
{
    public class ParentLanguage
    {
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
