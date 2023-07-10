using Moq;
using OffersManagement.Application.Offer;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.UnitTests.Offer.Commands.OfferUpdateCommandTest
{
    public class UpdateTest
    {

        public class Given_OfferUpdateCommand_When_Update_Offer
            : Given_When_Then_Test_Async
        {
            private readonly Mock<IProductRepository> _productRepository = new();

            private OfferUpdateCommandHandler _sut;

            private Domain.Entities.Offer _offerToUpdate;
            private Product _productToUpdate;

            protected override void Given()
            {
                var priceToUpdate = new Price(1, 30);
                var stockToUpdate = new Stock(1, 50);
                _productToUpdate = new Product(1, "T-Shirt", "Sarenza", "XL", priceToUpdate, stockToUpdate);
                _offerToUpdate = new Domain.Entities.Offer(_productToUpdate);

                _productRepository.Setup(s => s.AddProductAsync(_productToUpdate))
                                  .Verifiable();

                _sut = new OfferUpdateCommandHandler(_productRepository.Object);
            }

            protected override async Task When()
            {
                await _sut.HandleAsync(_offerToUpdate);
            }

            [Fact]
            public void Then_Should_Update_Offer()
            {
                _productRepository.Verify(v => v.UpdateProductAsync(_productToUpdate));
            }

        }

    }
}
