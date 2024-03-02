using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Repositories;
using ParentsAbroad.Services;

namespace ParentsAbroad.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


            #region Services

            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IChildService, ChildService>();

            #endregion


            #region Repositories

            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IParentLanguageRepository, ParentLanguageRepository>();

            #endregion

            return services;
        }
    }
}
