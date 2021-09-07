using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructureMapTest
{
    public interface IRestClient
    {
        Task<TResponse> GetAsync<TResponse>(string baseUri, string path, IList<HeaderDef> headers = null);
    }
}
