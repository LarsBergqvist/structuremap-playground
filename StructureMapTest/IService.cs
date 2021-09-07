using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructureMapTest
{
    public interface IService
    {
        Task<IList<Posts>> GetAllPosts();
    }
}
