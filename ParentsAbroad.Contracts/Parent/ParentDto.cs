using ParentsAbroad.Contracts.Hobby;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.Person;

namespace ParentsAbroad.Contracts.Parent
{
    public class ParentDto : PersonDto
    {
        public virtual IList<LanguageDto> Languages { get; set; }
        public virtual IList<HobbyDto> Hobbies { get; set; }
    }
}
