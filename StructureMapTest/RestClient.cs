using System;
using System.Collections.Generic;
using System.Net.Http;
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
        private IList<HeaderDef> _headers;
        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _headers = new List<HeaderDef>();
        }

        public void AddHeader(string key, string value)
        {
            _headers.Add(new HeaderDef() { Key = key, Value = value });

        }
        public string BaseUrl { get; set; }
        public string BasePath { get; set; }

        public TResponse Get<TResponse>(string path)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{BaseUrl}{path}"),
                Headers = {
                   { "X-Version", "1" }
                },
            };

            var response = _httpClient.SendAsync(httpRequestMessage).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TResponse>(responseBody);
                return result;
            }
            else
            {
                throw new Exception($"Error code: {response.StatusCode}");
            }
        }
    }
}
