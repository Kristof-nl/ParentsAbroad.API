namespace ParentsAbroad.Models.Models
{
    public class ChildLanguage
    {
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
