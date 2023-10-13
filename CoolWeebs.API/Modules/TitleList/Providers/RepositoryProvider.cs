using CoolWeebs.API.Modules.TitleList.Repositories;

namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static partial class RepositoryProvider
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITitleRepository, TitleRepository>();

            services.AddScoped<IListRepository, ListRepository>();

            return services;
        }
    }
}
