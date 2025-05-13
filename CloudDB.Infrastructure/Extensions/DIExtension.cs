using CloudDB.Infrastructure.Interfaces;
using CloudDB.Infrastructure.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace CloudDB.Infrastructure.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {

            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IIngredientRepo, IngredientRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IUserRepo, UserRepo>();

            return services;
        }
    }
}
