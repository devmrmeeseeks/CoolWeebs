using System.Reflection;
using System.Text;
using System.Web;

namespace CoolWeebs.API.utilities
{
    public class HttpClientUtility : IHttpClientUtility
    {
        private readonly HttpClient _httpClient;

        public HttpClientUtility(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<T?> GetAsync<T>(object uriObj, CancellationToken cancellationToken = default)
        {
            string uri = GetUriFromObject(uriObj);
            HttpResponseMessage response = await _httpClient.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            return default;
        }

        private String GetUriFromObject(object obj)
        {
            StringBuilder uriBuilder = new StringBuilder();
            uriBuilder.Append("?");
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                string name = property.Name;
                object? value = property.GetValue(obj, null);
                if (value is null) continue;

                uriBuilder.Append($"{name}={HttpUtility.UrlEncode(value.ToString())}&");
            }

            return uriBuilder.ToString();
        }
    }
}
