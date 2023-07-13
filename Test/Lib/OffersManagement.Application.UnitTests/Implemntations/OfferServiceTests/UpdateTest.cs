using Moq;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.UnitTests.Implemntations.OfferServiceTests
{
    public class UpdateTest
    {

        public class Given_OfferUpdateCommand_When_Update_Offer
            : Given_When_Then_Test_Async
        {
            private readonly Mock<IOfferRepository> _offerRepository = new();

            private OfferService _sut;
            private Offer _offerToUpdate;

            protected override void Given()
            {
                var priceToUpdate = new Price(1, 30);
                var stockToUpdate = new Stock(1, 50);
                var productToUpdate = new Product(1, "T-Shirt", "Sarenza", "XL");

                _offerToUpdate = new Offer(productToUpdate, priceToUpdate, stockToUpdate);

                _offerRepository.Setup(s => s.AddAsync(_offerToUpdate))
                                .Verifiable();

                _sut = new OfferService(_offerRepository.Object);
            }

            protected override async Task When()
            {
                await _sut.UpdateAsync(_offerToUpdate);
            }

            [Fact]
            public void Then_Should_Update_Offer()
            {
                _offerRepository.Verify(v => v.UpdateAsync(_offerToUpdate));
            }

        }

    }
}
