using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OneStream_Assessment_Services.FrontEnd
{
    public class FrontEndService : IFrontEndService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FrontEndService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            client.BaseAddress = new Uri(baseUrl);
            return client;
        }

        public async Task<string> CallApi1()
        {
            using var client = CreateClient();
            var response = await client.GetAsync("api1");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> CallApi2()
        {
            using var client = CreateClient();
            var response = await client.GetAsync("api2");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostToApi1(object data)
        {
            using var client = CreateClient();
            var response = await client.PostAsJsonAsync("api1", data);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostToApi2(object data)
        {
            using var client = CreateClient();
            var response = await client.PostAsJsonAsync("api2", data);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
