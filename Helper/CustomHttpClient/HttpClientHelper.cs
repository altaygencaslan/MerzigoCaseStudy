using Helper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Helper.CustomHttpClient
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void GenerateClient(string clientCode)
        {
            _httpClient = _httpClientFactory.CreateClient(clientCode);
        }

        public async Task<T> Delete<T, K>(string endpoint, K item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T, K>(string endpoint, K item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<T> Post<T, K>(string endpoint, K item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Put<T, K>(string endpoint, K item, CancellationToken token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
            request.Headers.Add("Accept", "application/json");

            request.Content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.SendAsync(request, token);

            if (httpResponse?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseSTR = await httpResponse.Content.ReadAsStringAsync(token);
                return JsonSerializer.Deserialize<ResultDto<T>>(responseSTR).Data;
            }

            return default;
        }
    }
}
