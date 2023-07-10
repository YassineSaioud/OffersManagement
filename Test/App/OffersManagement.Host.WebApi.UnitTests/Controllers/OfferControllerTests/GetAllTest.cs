using Microsoft.AspNetCore.Mvc;
using Moq;
using NFluent;
using OffersManagement.Host.WebApi.Controllers;
using System.Net;

namespace OffersManagement.Host.WebApi.UnitTests.Controllers.OfferControllerTests
{
    public class GetAllTest
    {
        public class Given_OfferController_When_GelAllOffers
            : Given_When_Then_Test_Async
        {

            private OfferController _sut;
            private IActionResult _result;

            private Mock<IOfferService> _offerService = new();

            protected override void Given()
            {
                _offerService.Setup(o => o.GetAllAsync()).ReturnsAsync(new List<OfferModel>
                                                    {
                                                        new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20),
                                                        new OfferModel(2, "T-Shirt", "Sarenza", "L", 40, 70)
                                                    });

                _sut = new OfferController(_offerService.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetAllAsync();
            }

            [Fact]
            public void Then_Should_Return_Ok_Result()
            {
                var checkedResult = _result as OkObjectResult;
                Check.That(checkedResult.StatusCode).Equals((int)HttpStatusCode.OK);
            }

            [Fact]
            public void Then_Should_Return_Offers()
            {
                var checkedResult = _result as OkObjectResult;
                var checkedOffers = checkedResult.Value as IEnumerable<OfferModel>;

                Check.That(checkedOffers.Any()).IsTrue();
            }

        }
    }
}
