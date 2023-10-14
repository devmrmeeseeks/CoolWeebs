using CoolWeebs.API.Database;
using CoolWeebs.API.Middlewares;
using CoolWeebs.API.Modules.TitleList.Providers;

namespace CoolWeebs.API
{
    public static class CoolWebsApiProvider
    {
        public static IServiceCollection AddCoolWeebsApi(this IServiceCollection services, IConfiguration configuration)
        {
            // Init API
            services.AddSwaggerGen();

            services.AddDatabaseProvider(configuration);

            services.AddTitleListModule();

            services.AddTransient<GlobalExceptionMiddleware>();

            services.AddAutoMapper(typeof(CoolWebsApiProvider));

            return services;
        }
    }
}
