using ParentsAbroad.Models.Models.Interfaces;

namespace ParentsAbroad.Models.Models
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public IList<ChildLanguage> ChildLanguages { get; set; }
        public IList<ParentLanguage> ParentLanguages { get; set; }
    }
}
