using NFluent;
using OffersManagement.Host.WebApi.UnitTests.Services;

namespace OffersManagement.Host.WebApi.UnitTests.Controllers.OfferServiceTests
{
    public class GetAllTest
    {
        public class Given_OfferService_When_GelAllOffers
            : Given_When_Then_Test
        {

            private SutBuilder _sutBuilder;
            private OfferService _sut;
            private IEnumerable<OfferModel> _result;

            protected override void Given()
            {
                _sutBuilder = new SutBuilder();
                _sut = _sutBuilder.WithHandleGetQuery()
                                  .WithConvertToOffersModels()
                                  .Build();
            }

            protected override void When()
            {
                _result = _sut.GetAll();
            }

            [Fact]
            public void Then_Should_Return_Offers()
            {
                Check.That(_result.Any()).IsTrue();
            }

            [Fact]
            public void Then_Verify_GetOffersQuery_Is_Handled()
            {
                _sutBuilder.VerifyGetQueryIsHandled();
            }


            [Fact]
            public void Then_Verify_OffersModels_Is_Converted()
            {
                _sutBuilder.VerifyOffersModelsIsConverted();
            }

        }
    }
}
