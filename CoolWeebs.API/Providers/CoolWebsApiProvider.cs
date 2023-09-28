using CoolWeebs.API.Configurations;
using CoolWeebs.API.Modules.TitleList.Providers;

namespace CoolWeebs.API.Providers
{
    public static class CoolWebsApiProvider
    {
        public static IServiceCollection AddCoolWeebsApi(this IServiceCollection services, IConfiguration configuration)
        {
            // Init API
            services.AddSwaggerGen();

            services.AddDatabaseProvider(configuration);

            services.AddAutoMapperProvider();

            services.AddTitleListModule();

            return services;
        }
    }
}
