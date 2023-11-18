namespace CoolWeebs.API.utilities
{
    public interface IHttpClientUtility
    {
        Task<T?> GetAsync<T>(string uri);
    }
}
