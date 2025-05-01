using Microsoft.Extensions.DependencyInjection;
using Posts_Infrastructure.Abstracts;
using Posts_Infrastructure.Implementations;
using Posts_Infrastructure.InfrastructureBases;

namespace Posts_Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
          
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
