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
            private readonly Mock<IProductRepository> _productRepository = new();

            private OfferService _sut;

            private Offer _offerToCreate;
            private Product _productToCreate;

            protected override void Given()
            {
                var priceToCreate = new Price(1, 30);
                var stockToCreate = new Stock(1, 50);
                _productToCreate = new Product(1, "T-Shirt", "Sarenza", "S", priceToCreate, stockToCreate);
                _offerToCreate = new Offer(_productToCreate);

                _productRepository.Setup(s => s.AddProductAsync(_productToCreate))
                                  .Verifiable();

                _sut = new OfferService(_productRepository.Object);
            }

            protected override async Task When()
            {
                await _sut.CreateAsync(_offerToCreate);
            }

            [Fact]
            public void Then_Should_Create_Offer()
            {
                _productRepository.Verify(v => v.AddProductAsync(_productToCreate));
            }

        }
    }
}
