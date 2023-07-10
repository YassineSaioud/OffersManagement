namespace OffersManagement.Host.WebApi.UnitTests.Services.OfferServiceTests
{
    public class UpdateTest
    {
        public class Given_OfferService_When_Update
           : Given_When_Then_Test_Async
        {

            private SutBuilder _sutBuilder;
            private OfferService _sut;

            private OfferModel offerToUpdate;

            protected override void Given()
            {
                _sutBuilder = new SutBuilder();
                _sut = _sutBuilder.WithConvertToOffer()
                                  .WithHandleUpdateCommand()
                                  .Build();
            }

            protected override async Task When()
            {
                offerToUpdate = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);
                await _sut.UpdateAsync(offerToUpdate);
            }

            [Fact]
            public void Then_Verify_Offer_Is_Converted()
            {
                _sutBuilder.WithConvertToOffer();
            }

            [Fact]
            public void Then_Verify_UpdateOfferCommad_Is_Handled()
            {
                _sutBuilder.VerifyUpdateCommandIsHandled();
            }

        }
    }
}
