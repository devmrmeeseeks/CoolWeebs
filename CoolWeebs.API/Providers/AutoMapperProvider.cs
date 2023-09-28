namespace CoolWeebs.API.Providers
{
    public static class AutoMapperProvider
    {
        public static IServiceCollection AddAutoMapperProvider(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProvider));
            return services;
        }
    }
}
