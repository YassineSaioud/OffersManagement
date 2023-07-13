using Moq;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.UnitTests.Implemntations.OfferServiceTests
{
    public class CreateTest
    {
        public class Given_OfferCreateCommand_When_Create_Offer
            : Given_When_Then_Test_Async
        {
            private readonly Mock<IOfferRepository> _offerRepository = new();

            private OfferService _sut;

            private Offer _offerToCreate;

            protected override void Given()
            {
                var priceToCreate = new Price(1, 30);
                var stockToCreate = new Stock(1, 50);
                var productToCreate = new Product(1, "T-Shirt", "Sarenza", "S");

                _offerToCreate = new Offer(productToCreate, priceToCreate, stockToCreate);

                _offerRepository.Setup(s => s.AddAsync(_offerToCreate))
                                .Verifiable();

                _sut = new OfferService(_offerRepository.Object);
            }

            protected override async Task When()
            {
                await _sut.CreateAsync(_offerToCreate);
            }

            [Fact]
            public void Then_Should_Create_Offer()
            {
                _offerRepository.Verify(v => v.AddAsync(_offerToCreate));
            }

        }
    }
}
