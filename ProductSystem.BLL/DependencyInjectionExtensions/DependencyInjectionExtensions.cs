using Microsoft.Extensions.DependencyInjection;
using ProductSystem.BLL.Managers;

namespace ProductSystem.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IProductManager, ProductManager>();
             services.AddScoped<ICategoryManager, CategoryManager>();

            return services;
        }
    }
}