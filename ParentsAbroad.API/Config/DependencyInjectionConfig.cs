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

            #endregion


            #region Repositories

            services.AddScoped<IFamilyRepository, FamilyRepository>();

            #endregion

            return services;
        }
    }
}
