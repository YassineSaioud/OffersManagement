using Microsoft.AspNetCore.Mvc;
using Moq;
using NFluent;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using OffersManagement.Host.WebApi.Controllers;
using System.Net;

namespace OffersManagement.Host.WebApi.UnitTests.Controllers.OfferControllerTests
{
    public class UpdateTest
    {
        public class Given_OfferControlle_When_Update
           : Given_When_Then_Test_Async
        {

            private OfferController _sut;
            private IActionResult _result;

            private OfferModel OfferToUpdate;

            private readonly Mock<IOfferService> _offerService = new();
            private readonly Mock<IOfferConverter> _offerConverter = new();

            protected override void Given()
            {
                OfferToUpdate = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);

                _offerConverter.Setup(s => s.Convert(OfferToUpdate))
                               .Verifiable();

                _offerService.Setup(o => o.UpdateAsync(It.IsAny<Offer>()))
                             .Verifiable();

                _sut = new OfferController(_offerService.Object, _offerConverter.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.UpdateAsync(OfferToUpdate);
            }

            [Fact]
            public void Then_Should_Convert_To_Offer()
            {
                _offerConverter.Verify(v => v.Convert(OfferToUpdate), Times.Once, "Should Convert To Offer.");
            }

            [Fact]
            public void Then_Should_Update_Offer()
            {
                _offerService.Verify(v => v.UpdateAsync(It.IsAny<Offer>()), Times.Once, "Should Update Offer.");
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
