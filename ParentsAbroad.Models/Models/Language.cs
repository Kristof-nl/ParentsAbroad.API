namespace ParentsAbroad.Models.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public IList<ChildLanguage> Children { get; set; }
    }
}
