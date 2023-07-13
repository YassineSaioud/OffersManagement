using Moq;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.StockRepositoryTest
{
    public class CreateTest
    {
        public class Given_StockRepository_When_Create_Stock
               : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IDbConnection> _dbProvider = new();


            private StockRepository _sut;
            private Stock _priceToCreate;

            protected override void Given()
            {
                _priceToCreate = new Stock(1, 20);

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .Verifiable();

                _sut = new StockRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                await _sut.AddStockAsync(_priceToCreate);
            }

            [Fact]
            public void Schould_Create_Stock_For_Product()
            {
                _dapperWrapper.Verify(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()), Times.Once);
            }

        }

    }
}
