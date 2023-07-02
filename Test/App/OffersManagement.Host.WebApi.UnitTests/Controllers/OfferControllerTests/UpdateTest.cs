using Microsoft.AspNetCore.Mvc;
using Moq;
using NFluent;
using OffersManagement.Host.WebApi.Controllers;
using System.Net;

namespace OffersManagement.Host.WebApi.UnitTests.Controllers.OfferControllerTests
{
    public class UpdateTest
    {
        public class Given_A_OfferModel_When_Update
           : Given_When_Then_Test
        {

            private OfferController _sut;
            private IActionResult _result;

            private OfferModel OfferToUpdate;
            private readonly Mock<IOfferService> _offerService = new();

            protected override void Given()
            {
                OfferToUpdate = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);

                _offerService.Setup(o => o.Update(OfferToUpdate))
                             .Verifiable();

                _sut = new OfferController(_offerService.Object);
            }

            protected override void When()
            {
                _result = _sut.Update(OfferToUpdate);
            }

            [Fact]
            public void Then_Should_Return_Ok_Result()
            {
                var checkedResult = _result as OkResult;
                Check.That(checkedResult.StatusCode).Equals((int)HttpStatusCode.OK);
            }

            [Fact]
            public void Then_Should_Update_Offer()
            {
                _offerService.Verify(v => v.Update(OfferToUpdate), Times.Once, "Should Update Offer.");
            }

        }
    }
}
