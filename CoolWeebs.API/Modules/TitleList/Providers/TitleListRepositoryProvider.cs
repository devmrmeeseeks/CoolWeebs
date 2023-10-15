using CoolWeebs.API.Modules.TitleList.Repositories;

namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static class TitleListRepositoryProvider
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IListRepository, ListRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
