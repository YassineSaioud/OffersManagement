using Microsoft.AspNetCore.Mvc;
using Moq;
using NFluent;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
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
            private readonly Mock<IOfferConverter> _offerConverter = new();

            protected override void Given()
            {
                _offerConverter.Setup(s => s.Convert(It.IsAny<IEnumerable<Offer>>()))
                               .Returns(new List<OfferModel> {
                                   new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20),
                                   new OfferModel(2, "T-Shirt", "Sarenza", "L", 40, 70)
                               });

                _offerService.Setup(o => o.GetAllAsync()).Verifiable();

                _sut = new OfferController(_offerService.Object, _offerConverter.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetAllAsync();
            }


            [Fact]
            public void Then_Should_Convert_To_Offers()
            {
                _offerConverter.Verify(s => s.Convert(It.IsAny<IEnumerable<Offer>>()), Times.Once);
            }

            [Fact]
            public void Then_Should_Return_All_Offers()
            {
                _offerService.Verify(s => s.GetAllAsync(), Times.Once);
            }

            [Fact]
            public void Then_Should_Return_Offers()
            {
                var checkedResult = _result as OkObjectResult;
                var checkedOffers = checkedResult.Value as IEnumerable<OfferModel>;

                Check.That(checkedOffers.Any()).IsTrue();
            }

            [Fact]
            public void Then_Should_Return_Ok_Result()
            {
                var checkedResult = _result as OkObjectResult;
                Check.That(checkedResult.StatusCode).Equals((int)HttpStatusCode.OK);
            }

        }
    }
}
