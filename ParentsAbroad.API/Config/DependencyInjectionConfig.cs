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

            #endregion


            #region Repositories

            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();

            #endregion

            return services;
        }
    }
}
