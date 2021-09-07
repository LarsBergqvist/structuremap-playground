namespace StructureMapTest
{
    public interface IRestClient
    {
        TResponse Get<TResponse>(string path);
        void AddHeader(string key, string value);
        string BaseUrl { get; set; }
        string BasePath { get; set; }
    }
}
