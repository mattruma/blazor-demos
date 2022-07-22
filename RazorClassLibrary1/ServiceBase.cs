namespace RazorClassLibrary1
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient _httpClient;

        public ServiceBase(
            IHttpClientFactory httpClientFactory,
            string name)
        {
            _httpClient = httpClientFactory.CreateClient(name);
        }
    }
}
