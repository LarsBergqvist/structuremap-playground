using System.Collections.Generic;

namespace StructureMapTest
{
    public interface IService
    {
        IList<Posts> GetAllPosts();
    }
}
