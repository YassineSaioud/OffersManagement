using Microsoft.AspNetCore.Mvc;
using Moq;
using NFluent;
using OffersManagement.Host.WebApi.Controllers;
using System.Net;

namespace OffersManagement.Host.WebApi.UnitTests.Controllers.OfferControllerTests
{
    public class CreateTest
    {
        public class Given_OfferControlle_When_Create
           : Given_When_Then_Test
        {

            private OfferController _sut;
            private IActionResult _result;

            private OfferModel OfferToAdd;
            private readonly Mock<IOfferService> _offerService = new();

            protected override void Given()
            {
                OfferToAdd = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);

                _offerService.Setup(o => o.Create(OfferToAdd))
                             .Verifiable();

                _sut = new OfferController(_offerService.Object);
            }

            protected override void When()
            {
                _result = _sut.Create(OfferToAdd);
            }

            [Fact]
            public void Then_Should_Return_Ok_Result()
            {
                var checkedResult = _result as OkResult;
                Check.That(checkedResult.StatusCode).Equals((int)HttpStatusCode.OK);
            }

            [Fact]
            public void Then_Should_Create_Offer()
            {
                _offerService.Verify(v => v.Create(OfferToAdd), Times.Once, "Should Create Offer.");
            }

        }
    }
}
