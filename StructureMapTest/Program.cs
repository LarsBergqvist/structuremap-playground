using System.Net.Http;
using StructureMap;

namespace StructureMapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.For<HttpClient>().Singleton().UseIfNone<HttpClient>();
                _.For<HttpMessageHandler>().UseIfNone(x => new HttpClientHandler());
                _.For<IService>().Use<Service>()
                .Ctor<string>("baseUrl").Is("https://jsonplaceholder.typicode.com/");
                _.Scan(c =>
                {
                    c.TheCallingAssembly();
                    c.WithDefaultConventions();

                });
            });
            var service = container.GetInstance<IService>();
            var result = service.GetAllPosts();
        }

    }
}
