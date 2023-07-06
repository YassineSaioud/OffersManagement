namespace OffersManagement.Host.WebApi.UnitTests.Services.OfferServiceTests
{
    public class CreateTest
    {
        public class Given_Service_When_Create
            : Given_When_Then_Test
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

            protected override void When()
            {
                offerToCreate = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);
                _sut.Create(offerToCreate);
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
