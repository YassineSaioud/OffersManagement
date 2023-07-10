namespace OffersManagement.Host.WebApi.UnitTests.Services.OfferServiceTests
{
    public class CreateTest
    {
        public class Given_OfferService_When_Create
            : Given_When_Then_Test_Async
        {

            private SutBuilder _sutBuilder;
            private OfferService _sut;

            private OfferModel offerToCreate;

            protected override void Given()
            {
                _sutBuilder = new SutBuilder();
                _sut = _sutBuilder.WithHandleCreateCommand()
                                  .WithConvertToOffer()
                                  .Build();
            }

            protected override async Task When()
            {
                offerToCreate = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);
                await _sut.CreateAsync(offerToCreate);
            }


            [Fact]
            public void Then_Verify_Offer_Is_Converted()
            {
                _sutBuilder.VerifyOfferIsConverted();
            }

            [Fact]
            public void Then_Verify_CreateOfferCommad_Is_Handled()
            {
                _sutBuilder.VerifyCreateCommandIsHandled();
            }

        }

    }
}
