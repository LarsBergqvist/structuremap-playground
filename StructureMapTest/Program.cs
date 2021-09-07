using System.Net.Http;
using System.Threading.Tasks;
using StructureMap;

namespace StructureMapTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.For<HttpClient>().Singleton().UseIfNone<HttpClient>().SelectConstructor(() => new HttpClient());
                _.For<HttpMessageHandler>().UseIfNone(x => new HttpClientHandler());
                _.For<IService>().Use<Service>()
                .Ctor<string>("baseUri").Is("https://jsonplaceholder.typicode.com/");
                _.Scan(c =>
                {
                    c.AssemblyContainingType<Service>();
                    c.WithDefaultConventions();

                });
            });
            var service = container.GetInstance<IService>();
            var result = await service.GetAllPosts();
            var result2 = await service.GetAllPosts();
        }

    }
}
