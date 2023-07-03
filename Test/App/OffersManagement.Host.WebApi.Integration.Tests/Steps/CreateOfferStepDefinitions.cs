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
    public class CreateOfferStepDefinitions
    {

        private readonly HttpClientFactory _httpClientFactory;
        private readonly IDapperWrapperMock _dapperWrapper;

        private HttpClient _httpClient;
        private HttpStatusCode _statusCode;
        private OfferModel _offer;

        public CreateOfferStepDefinitions(HttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _dapperWrapper = new DapperWrapperMock(new NpgsqlConnection("Server=localhost;Database=offers;User Id=sarenzaUser;Password=sarenza2023;"));
        }

        [Given(@"the offer to create")]
        public void GivenTheOfferToCreate(Table table)
        {
            _httpClient = _httpClientFactory.Create();
            _offer = table.CreateInstance<OfferModel>();
        }

        [When(@"add offer into offers data base")]
        public void WhenAddOfferIntoOffersDataBase()
        {
            var content = new StringContent(JsonConvert.SerializeObject(_offer));
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var result = _httpClient.PostAsync("api/offer/Add", content).Result;
            _statusCode = result.StatusCode;
        }

        [Then(@"the add http response status is ok")]
        public void ThenTheAddHttpResponseStatusIsOk()
        {
            Check.That(_statusCode).Equals(HttpStatusCode.OK);
        }

        [Then(@"the product info price info and stock info are persisted")]
        public void ThenTheProductInfoPriceInfoAndStockInfoArePersisted()
        {
            var insertedProduct = _dapperWrapper.QuerySingle<ProductDto>("select * from  product Where id=@productId", new { productId = _offer.ProductId });
            var insertedPrice = _dapperWrapper.QuerySingle<PriceDto>("select * from price Where product_id=@productId", new { productId = _offer.ProductId });
            var insertedStock = _dapperWrapper.QuerySingle<StockDto>("select * from stock Where product_id=@productId", new { productId = _offer.ProductId });

            Check.That(insertedProduct).IsNotNull();
            Check.That(insertedPrice).IsNotNull();
            Check.That(insertedStock).IsNotNull();
        }

        [AfterScenario("CleanInsertedOffer")]
        public void CleanInsertedOffer()
        {
            _dapperWrapper.Execute("Delete from product Where id=@productId", new { productId = _offer.ProductId });
            _dapperWrapper.Execute("Delete from price Where product_id=@productId", new { productId = _offer.ProductId });
            _dapperWrapper.Execute("Delete from stock Where product_id=@productId", new { productId = _offer.ProductId });
        }

    }
}
