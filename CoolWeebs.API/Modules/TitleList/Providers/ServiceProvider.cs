using CoolWeebs.API.Modules.TitleList.Services;

namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static partial class ServiceProvider
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITitleService, TitleService>();

            return services;
        }
    }
}
