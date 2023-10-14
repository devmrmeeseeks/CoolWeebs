namespace CoolWeebs.API.Modules.TitleList.Providers
{
    public static class TitleListModuleProvider
    {
        public static IServiceCollection AddTitleListModule(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();
            services.AddValidators();

            return services;
        }
    }
}
