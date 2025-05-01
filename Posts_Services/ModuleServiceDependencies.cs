
using Microsoft.Extensions.DependencyInjection;
using Posts_Service.Abstracts;
using Posts_Service.Implementations;
using Posts_Services.Abstracts;
using Posts_Services.Implementations;

namespace Posts_Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();


            return services;
        }
    }
}
