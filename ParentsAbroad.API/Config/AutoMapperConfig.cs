using AutoMapper;
using ParentsAbroad.Contracts;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Family, FamilyDto>();
            CreateMap<FamilyCreateUpdateDto, Family>();

            CreateMap<Child, ChildDto>();
            CreateMap<ChildCreateUpdateDto, Child>();

            CreateMap<Parent, ParentDto>();
            CreateMap<ParentCreateUpdateDto, Parent>();

        }
    }
}
