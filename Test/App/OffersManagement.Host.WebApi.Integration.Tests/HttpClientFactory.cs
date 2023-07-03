namespace OffersManagement.Host.WebApi.Integration.Tests
{
    public class HttpClientFactory
    {
        private readonly CustomWebApplicationFactory _webApplicationFactory;

        public HttpClientFactory(CustomWebApplicationFactory webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        public HttpClient Create()
        {
            var client = _webApplicationFactory.CreateClient();
            return client;
        }

    }
}
