using ParentsAbroad.Contracts.Person;

namespace ParentsAbroad.Contracts.Parent
{
    public class ParentDto : PersonDto
    {
        public virtual IList<LanguageDto> Languages { get; set; }
    }
}
