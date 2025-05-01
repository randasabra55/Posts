using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Posts_Core.Behaviors;
using System.Reflection;

namespace Posts_Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //Configuration Of Mediator
            services.AddMediatR(cfg =>
                     cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //  services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }

    }
}
