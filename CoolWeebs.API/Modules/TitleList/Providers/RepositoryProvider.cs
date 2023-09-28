using CoolWeebs.API.Modules.TitleList.Repositories;

namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static partial class RepositoryProvider
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITitleRepository, TitleRepository>();

            services.AddTransient<IListRepository, ListRepository>();

            return services;
        }
    }
}
