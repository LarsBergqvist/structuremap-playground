using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StructureMapTest
{
    public class HeaderDef
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;
        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResponse> GetAsync<TResponse>(string baseUri, string path, IList<HeaderDef> headers)
        {
            using (var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUri}{path}"),
            })
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        httpRequestMessage.Headers.Add(header.Key, header.Value);
                    }
                }

                var response = await _httpClient.SendAsync(httpRequestMessage);
                if (!response.IsSuccessStatusCode) throw new Exception($"Error code: {response.StatusCode}");
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TResponse>(responseBody);
                return result;
            }
        }
    }
}
