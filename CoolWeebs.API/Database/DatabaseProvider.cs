using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Database
{
    public static class DatabaseProvider
    {
        public static IServiceCollection AddDatabaseProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
