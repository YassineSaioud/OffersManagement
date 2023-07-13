using Moq;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.ProductRepositoryTest
{
    public class UpdateTest
    {

        public class Given_ProductRepository_When_Update_Offer
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IDbConnection> _dbProvider = new();

            private ProductRepository _sut;
            private Product _productToUpdate;

            protected override void Given()
            {
                var priceToUpdate = new Price(1, 60);
                var stockToUpdate = new Stock(1, 100);
                _productToUpdate = new Product(1, "T-Shirt", "Sarenza", "XL");

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .Verifiable();

                _sut = new ProductRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                await _sut.UpdateAsync(_productToUpdate);
            }

            [Fact]
            public void Then_Should_Update_Product()
            {
                _dapperWrapper.Verify(v => v.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()), Times.Once);
            }

        }

    }
}
