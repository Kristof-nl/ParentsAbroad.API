using AutoMapper;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Family;
using ParentsAbroad.Contracts.Hobby;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.LikeToDo;
using ParentsAbroad.Contracts.Parent;
using ParentsAbroad.Contracts.School_Subject;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Family, FamilyDto>();
            CreateMap<FamilyCreateUpdateDto, Family>();
            CreateMap<Family, ShortFamilyDto>();


            CreateMap<Child, ChildDto>()
                 .ForMember(dest => dest.Languages, opt =>
                opt.MapFrom(src => src.ChildLanguages.Select(l => l.Language)))
                   .ForMember(dest => dest.SchoolSubjects, opt =>
                opt.MapFrom(src => src.ChildSchoolSubjects.Select(l => l.SchoolSubject)))
                   .ForMember(dest => dest.LikeToDoThings, opt =>
                opt.MapFrom(src => src.ChildLikeToDoThings.Select(l => l.LikeToDo)));
            CreateMap<ChildCreateUpdateDto, Child>();


            CreateMap<Parent, ParentDto>()
                .ForMember(dest => dest.Languages, opt =>
                opt.MapFrom(src => src.ParentLanguages.Select(l => l.Language)))
                 .ForMember(dest => dest.Hobbies, opt =>
                opt.MapFrom(src => src.ParentHobbys.Select(l => l.Hobby)));
            CreateMap<ParentCreateUpdateDto, Parent>();


            CreateMap<Language, LanguageDto>();
            CreateMap<SchoolSubject, SchoolSubjectDto>();
            CreateMap<LikeToDo, LikeToDoDto>();
            CreateMap<Hobby, HobbyDto>();
        }
    }
}
