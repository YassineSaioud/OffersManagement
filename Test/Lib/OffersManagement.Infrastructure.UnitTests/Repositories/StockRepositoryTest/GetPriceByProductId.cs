using Moq;
using NFluent;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.StockRepositoryTest
{
    public class GetStockByProductId
    {

        public class Given_StockRepository_When_GetStockByProduct
            : Given_When_Then_Test
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();

            private StockRepository _sut;
            private Stock _result;

            protected override void Given()
            {
                _dapperWrapper.Setup(s => s.QuerySingle<StockDto>(It.IsAny<string>(), It.IsAny<object>()))
                              .Returns(new StockDto { ProductId = 1, Quantity = 100 });

                _sut = new StockRepository(_dapperWrapper.Object);
            }

            protected override void When()
            {
                _result = _sut.GetStockByProductId(1);
            }

            [Fact]
            public void Schould_Return_Stock_By_ProductId()
            {
                Check.That(_result).IsNotNull();
            }

        }

    }

}

