using Newtonsoft.Json;
using NFluent;
using Npgsql;
using System.Net;
using System.Net.Http.Headers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OffersManagement.Host.WebApi.Integration.Tests
{
    [Binding]
    public class UpdateOfferStepDefinitions
    {

        private readonly HttpClientFactory _httpClientFactory;
        private readonly IDapperWrapperMock _dapperWrapper;

        private HttpClient _httpClient;
        private HttpStatusCode _statusCode;
        private OfferModel _offer;

        public UpdateOfferStepDefinitions(HttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _dapperWrapper = new DapperWrapperMock(new NpgsqlConnection("Server=localhost;Database=offers;User Id=sarenzaUser;Password=sarenza2023;"));
        }

        [Given(@"the existing offer to update")]
        public void GivenTheExistingOfferToUpdate(Table table)
        {
            _httpClient = _httpClientFactory.Create();
            _offer = table.CreateInstance<OfferModel>();
        }

        [When(@"update product size price and quantity")]
        public void WhenUpdateOfferIntoOffersDataBase()
        {
            var content = new StringContent(JsonConvert.SerializeObject(_offer));
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var result = _httpClient.PutAsync("api/offer/Update", content).Result;
            _statusCode = result.StatusCode;
        }

        [Then(@"the update http response status is ok")]
        public void ThenTheUpdateHttpResponseStatusIsOk()
        {
            Check.That(_statusCode).Equals(HttpStatusCode.OK);
        }

        [Then(@"the product info price info and stock info are updated")]
        public void ThenTheProductInfoPriceInfoAndStockInfoAreUpdated()
        {
            var updatedProduct = _dapperWrapper.QuerySingle<ProductDto>("select * from  product Where id=@productId", new { productId = _offer.ProductId });
            var updatedPrice = _dapperWrapper.QuerySingle<PriceDto>("select * from price Where product_id=@productId", new { productId = _offer.ProductId });
            var updatedStock = _dapperWrapper.QuerySingle<StockDto>("select * from stock Where product_id=@productId", new { productId = _offer.ProductId });

            Check.That(updatedProduct.Size).Equals(_offer.ProductSize);
            Check.That(updatedPrice.Value).Equals(_offer.Price);
            Check.That(updatedStock.Quantity).Equals(_offer.Quantity);
        }
    }
}
