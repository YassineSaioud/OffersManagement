using Newtonsoft.Json;
using NFluent;
using System.Net;
using TechTalk.SpecFlow;

namespace OffersManagement.Host.WebApi.Integration.Tests
{
    [Binding]
    public class GetAllOffersStepDefinitions
    {

        private readonly HttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        private IEnumerable<OfferModel> _offers;
        private HttpStatusCode _statusCode;

        public GetAllOffersStepDefinitions(HttpClientFactory httpClientFactory)

        {
            _httpClientFactory = httpClientFactory;
        }

        [Given(@"offer controller")]
        public void GivenOfferController()
        {
            _httpClient = _httpClientFactory.Create();
        }

        [When(@"try to get all affers")]
        public void WhenTryToGetAllAffers()
        {
            var respone = _httpClient.GetAsync("api/offer/All").GetAwaiter().GetResult();
            _statusCode = respone.StatusCode;
            _offers = JsonConvert.DeserializeObject<IEnumerable<OfferModel>>(respone.Content.ReadAsStringAsync().Result);
        }

        [Then(@"the http response status is ok")]
        public void ThenTheHttpResponseStatusIsOk()
        {
            Check.That(_statusCode).Equals(HttpStatusCode.OK);
        }


        [Then(@"all offers are geted")]
        public void ThenFollowingOffersAreGeted()
        {
            Check.That(_offers.Any()).IsTrue();
        }


    }
}
