using Moq;
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
            private Mock<IDbConnection> _dbProvider = new();

            private ProductRepository _sut;
            private Product _productToCreate;

            protected override void Given()
            {

                _productToCreate = new Product(1, "T-Shirt", "Sarenza", "S");

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .Verifiable();

                _sut = new ProductRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                await _sut.AddAsync(_productToCreate);
            }

            [Fact]
            public void Then_Should_Create_Product()
            {
                _dapperWrapper.Verify(v => v.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()), Times.Once);
            }

        }

    }
}
