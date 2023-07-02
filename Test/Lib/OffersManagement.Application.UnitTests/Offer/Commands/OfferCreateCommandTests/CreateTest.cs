using Moq;
using OffersManagement.Application.Offer;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.UnitTests.Offer.Commands.OfferCreateCommandTests
{
    public class CreateTest
    {
        public class Given_OfferCreateCommand_When_Create_Offer
            : Given_When_Then_Test
        {
            private readonly Mock<IProductRepository> _productRepository = new();

            private OfferCreateCommand _sut;

            private Domain.Entities.Offer _offerToCreate;
            private Product _productToCreate;

            protected override void Given()
            {
                var priceToCreate = new Price(1, 30);
                var stockToCreate = new Stock(1, 50);
                _productToCreate = new Product(1, "T-Shirt", "Sarenza", "S", priceToCreate, stockToCreate);
                _offerToCreate = new Domain.Entities.Offer(_productToCreate);

                _productRepository.Setup(s => s.AddProduct(_productToCreate))
                                  .Verifiable();

                _sut = new OfferCreateCommand(_productRepository.Object);
            }

            protected override void When()
            {
                _sut.Handle(_offerToCreate);
            }

            [Fact]
            public void Then_Should_Create_Offer()
            {
                _productRepository.Verify(v => v.AddProduct(_productToCreate));
            }

        }
    }
}
