using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.Person;
using ParentsAbroad.Contracts.School_Subject;

namespace ParentsAbroad.Contracts.Child
{
    public class ChildDto : PersonDto
    {
        public virtual IList<LanguageDto> Languages { get; set; }
        public virtual IList<SchoolSubjectDto> SchoolSubjects { get; set; }
    }
}
