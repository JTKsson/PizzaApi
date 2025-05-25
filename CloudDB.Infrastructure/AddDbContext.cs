using CloudDB.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudDB.Infrastructure
{
    public static class AddDbContext
    {
        public static IServiceCollection AddExtendedContext(this IServiceCollection services,
                                                           IConfiguration configuration
                                                   )
        {
            var connString = configuration.GetConnectionString("DBConnString");

            services.AddDbContext<ApplicationUserContext>(options =>

                    options.UseSqlServer(connString)

                );
            services.AddDbContext<ApplicationUserContext>(options =>
                options.UseSqlServer(connString, x => x.MigrationsAssembly("CloudDB.Infrastructure"))
);

            return services;

        }
    }
}
