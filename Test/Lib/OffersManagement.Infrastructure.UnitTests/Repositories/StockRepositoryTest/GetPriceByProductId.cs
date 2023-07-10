using Moq;
using NFluent;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.StockRepositoryTest
{
    public class GetStockByProductId
    {

        public class Given_StockRepository_When_GetStockByProduct
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();

            private StockRepository _sut;
            private Stock _result;

            protected override void Given()
            {
                _dapperWrapper.Setup(s => s.QuerySingleAsync<StockDto>(It.IsAny<string>(), It.IsAny<object>()))
                              .ReturnsAsync(new StockDto { ProductId = 1, Quantity = 100 });

                _sut = new StockRepository(_dapperWrapper.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetStockByProductIdAsync(1);
            }

            [Fact]
            public void Schould_Return_Stock_By_ProductId()
            {
                Check.That(_result).IsNotNull();
            }

        }

    }

}

