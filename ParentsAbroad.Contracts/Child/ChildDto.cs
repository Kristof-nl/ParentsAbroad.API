using ParentsAbroad.Contracts.Family;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.Person;

namespace ParentsAbroad.Contracts.Child
{
    public class ChildDto : PersonDto
    {
        public virtual IList<LanguageDto> Languages { get; set; }
    }
}
