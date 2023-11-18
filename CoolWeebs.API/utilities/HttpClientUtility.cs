namespace CoolWeebs.API.utilities
{
    public class HttpClientUtility : IHttpClientUtility
    {
        private readonly HttpClient _httpClient;

        public HttpClientUtility(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<T?> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            return default;
        }
    }
}
