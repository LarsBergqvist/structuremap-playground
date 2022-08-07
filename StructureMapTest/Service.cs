using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructureMapTest
{
    public class Service : IService
    {
        private readonly IRestClient _restClient;
        private readonly string _baseUri;
        public Service(IRestClient restClient, string baseUri)
        {
            _restClient = restClient;
            _baseUri = baseUri;
        }
        public async Task<IList<Post>> GetAllPosts()
        {
            var headers = new List<HeaderDef>
            {
                new HeaderDef {Key = "header1", Value = "value1"},
                new HeaderDef {Key = "header2", Value = "value2"}
            };
            return await _restClient.GetAsync<IList<Post>>(_baseUri, "posts", headers);
        }
    }
}
