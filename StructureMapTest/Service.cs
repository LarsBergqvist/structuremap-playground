using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapTest
{
    public class Service : IService
    {
        private readonly IRestClient _restClient;
        public Service(IRestClient restClient, string baseUrl)
        {
            _restClient = restClient;
            _restClient.BasePath = "basePath";
            _restClient.BaseUrl = baseUrl;
            _restClient.AddHeader("key1", "value1");
            _restClient.AddHeader("key2", "value2");
        }
        public IList<Posts> GetAllPosts()
        {
            return _restClient.Get<IList<Posts>>("posts");
        }
    }
}
