using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Application.Behaviors;
using System.Reflection;

namespace ProductManagementSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(configuration => 
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
