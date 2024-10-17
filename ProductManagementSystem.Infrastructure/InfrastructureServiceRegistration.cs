using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Domain.Interfaces;
using ProductManagementSystem.Infrastructure.Repositories;
using ProductManagementSystem.Infrastructure.Services;

namespace ProductManagementSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryService, InventoryService>();

            return services;
        }
    }
}
