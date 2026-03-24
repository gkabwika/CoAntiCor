namespace CoAntiCor.Services
{
    using System.Net.Http.Json;

    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            return await _http.GetFromJsonAsync<T>(url);
        }

        public async Task<T?> PostAsync<T>(string url, object payload)
        {
            var response = await _http.PostAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task PostAsync(string url, object payload)
        {
            var response = await _http.PostAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(string url, object payload)
        {
            var response = await _http.PutAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
        }
    }

}
