using Moq;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.ProductRepositoryTest
{
    public class UpdateTest
    {

        public class Given_ProductRepository_When_Update_Offer
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IPriceRepository> _priceRepository = new();
            private Mock<IStockRepository> _stockRepository = new();

            private ProductRepository _sut;
            private Product _productToUpdate;

            protected override void Given()
            {
                var priceToUpdate = new Price(1, 60);
                var stockToUpdate = new Stock(1, 100);
                _productToUpdate = new Product(1, "T-Shirt", "Sarenza", "XL", priceToUpdate, stockToUpdate);

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                              .Verifiable();

                _priceRepository.Setup(s => s.UpdatePriceAsync(It.IsAny<Price>())).Verifiable();

                _stockRepository.Setup(s => s.UpdateStockAsync(It.IsAny<Stock>())).Verifiable();

                _sut = new ProductRepository(_dapperWrapper.Object, _priceRepository.Object, _stockRepository.Object);
            }

            protected override async Task When()
            {
                await _sut.UpdateProductAsync(_productToUpdate);
            }

            [Fact]
            public void Then_Should_Update_Product()
            {
                _dapperWrapper.Verify(v => v.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            }

            [Fact]
            public void Then_Should_Update_Price()
            {
                _priceRepository.Verify(s => s.UpdatePriceAsync(It.IsAny<Price>()), Times.Once);
            }

            [Fact]
            public void Then_Should_Update_Stock()
            {
                _stockRepository.Verify(s => s.UpdateStockAsync(It.IsAny<Stock>()), Times.Once);
            }

        }

    }
}
