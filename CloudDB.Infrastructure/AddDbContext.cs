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

            services.AddDbContext<CloudDBContext>(options =>

                    options.UseSqlServer(connString)

                );

            return services;

        }
    }
}
