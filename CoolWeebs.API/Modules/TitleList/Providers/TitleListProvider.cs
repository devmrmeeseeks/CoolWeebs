namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static class TitleListProvider
    {
        public static IServiceCollection AddTitleListModule(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();

            return services;
        }
    }
}
