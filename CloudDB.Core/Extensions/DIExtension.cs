using CloudDB.Core.Interfaces;
using CloudDB.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CloudDB.Core.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services)
        {

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAccountService, AccountService>();


            return services;
        }
    }
}
