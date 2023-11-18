using CoolWeebs.API.Database;
using CoolWeebs.API.Middlewares;
using CoolWeebs.API.Modules.TitleList.Providers;
using CoolWeebs.API.utilities;

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

            services.AddHttpClient<IHttpClientUtility, HttpClientUtility>((provider, client) =>
            {
                client.BaseAddress = new Uri(configuration["HttpClientSettings:JikanUrl"]);
            });

            return services;
        }
    }
}
