using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Repositories;

namespace ParentsAbroad.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
