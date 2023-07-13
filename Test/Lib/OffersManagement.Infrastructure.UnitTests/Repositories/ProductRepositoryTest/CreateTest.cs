using Moq;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.ProductRepositoryTest
{
    public class CreateTest
    {
        public class Given_ProductRepository_When_Create_Offer
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IPriceRepository> _priceRepository = new();
            private Mock<IStockRepository> _stockRepository = new();
            private Mock<IDbConnection> _dbProvider = new();

            private ProductRepository _sut;
            private Product _productToCreate;

            protected override void Given()
            {
                var priceToCreate = new Price(1, 30);
                var stockToCreate = new Stock(1, 50);
                _productToCreate = new Product(1, "T-Shirt", "Sarenza", "S", priceToCreate, stockToCreate);

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .Verifiable();

                _priceRepository.Setup(s => s.AddPriceAsync(It.IsAny<Price>())).Verifiable();

                _stockRepository.Setup(s => s.AddStockAsync(It.IsAny<Stock>())).Verifiable();

                _sut = new ProductRepository(_dapperWrapper.Object, _priceRepository.Object, _stockRepository.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                await _sut.AddProductAsync(_productToCreate);
            }

            [Fact]
            public void Then_Should_Create_Product()
            {
                _dapperWrapper.Verify(v => v.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()), Times.Once);
            }

            [Fact]
            public void Then_Should_Create_Price()
            {
                _priceRepository.Verify(s => s.AddPriceAsync(It.IsAny<Price>()), Times.Once);
            }

            [Fact]
            public void Then_Should_Create_Stock()
            {
                _stockRepository.Verify(s => s.AddStockAsync(It.IsAny<Stock>()), Times.Once);
            }


        }

    }
}
