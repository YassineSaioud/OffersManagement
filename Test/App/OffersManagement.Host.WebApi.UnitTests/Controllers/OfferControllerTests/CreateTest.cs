using Microsoft.AspNetCore.Mvc;
using Moq;
using NFluent;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using OffersManagement.Host.WebApi.Controllers;
using System.Net;

namespace OffersManagement.Host.WebApi.UnitTests.Controllers.OfferControllerTests
{
    public class CreateTest
    {
        public class Given_OfferControlle_When_Create
           : Given_When_Then_Test_Async
        {

            private OfferController _sut;
            private IActionResult _result;

            private OfferModel OfferToAdd;
            private readonly Mock<IOfferService> _offerService = new();
            private readonly Mock<IOfferConverter> _offerConverter = new();

            protected override void Given()
            {
                OfferToAdd = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);


                _offerConverter.Setup(s => s.Convert(OfferToAdd))
                               .Verifiable();

                _offerService.Setup(o => o.UpdateAsync(It.IsAny<Offer>()))
                             .Verifiable();

                _sut = new OfferController(_offerService.Object, _offerConverter.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.CreateAsync(OfferToAdd);
            }

            [Fact]
            public void Then_Should_Convert_To_Offer()
            {
                _offerConverter.Verify(v => v.Convert(OfferToAdd), Times.Once, "Should Convert To Offer.");
            }

            [Fact]
            public void Then_Should_Create_Offer()
            {
                _offerService.Verify(v => v.CreateAsync(It.IsAny<Offer>()), Times.Once, "Should Create Offer.");
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
