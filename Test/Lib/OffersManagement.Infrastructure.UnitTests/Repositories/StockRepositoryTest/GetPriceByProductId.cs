using Moq;
using NFluent;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.StockRepositoryTest
{
    public class GetStockByProductId
    {

        public class Given_StockRepository_When_GetStockByProduct
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IDbConnection> _dbProvider = new();

            private StockRepository _sut;
            private Stock _result;

            protected override void Given()
            {
                _dapperWrapper.Setup(s => s.QuerySingleAsync<StockDto>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .ReturnsAsync(new StockDto { ProductId = 1, Quantity = 100 });

                _sut = new StockRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetByProductIdAsync(1);
            }

            [Fact]
            public void Schould_Return_Stock_By_ProductId()
            {
                Check.That(_result).IsNotNull();
            }

        }

    }

}

