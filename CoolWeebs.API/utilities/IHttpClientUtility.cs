namespace CoolWeebs.API.utilities
{
    public interface IHttpClientUtility
    {
        Task<T?> GetAsync<T>(object uriObj, CancellationToken cancellationToken = default);
    }
}
