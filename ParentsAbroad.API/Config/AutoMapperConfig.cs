using AutoMapper;
using ParentsAbroad.Contracts;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Family;
using ParentsAbroad.Contracts.Parent;
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


            CreateMap<Child, ChildDto>();
            CreateMap<ChildCreateUpdateDto, Child>();

            CreateMap<Parent, ParentDto>()
                .ForMember(dest => dest.Languages, opt =>
                opt.MapFrom(src => src.ParentLanguages.Select(l => l.Language)));
            CreateMap<ParentCreateUpdateDto, Parent>();

            CreateMap<Language, LanguageDto>();

        }
    }
}
