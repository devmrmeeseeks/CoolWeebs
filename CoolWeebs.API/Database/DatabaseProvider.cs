using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Database
{
    public static class DatabaseProvider
    {
        public static IServiceCollection AddDatabaseProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                var serverVersion = new MariaDbServerVersion(new Version(10, 6));
                options.UseMySql(connectionString, serverVersion);
            });

            return services;
        }
    }
}
