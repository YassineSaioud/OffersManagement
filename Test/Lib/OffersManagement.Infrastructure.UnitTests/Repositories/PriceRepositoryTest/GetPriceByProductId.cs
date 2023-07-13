using Moq;
using NFluent;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.PriceRepositoryTest
{
    public class GetPriceByProductId
    {

        public class Given_PriceRepository_When_GetPriceByProduct
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IDbConnection> _dbProvider = new();

            private PriceRepository _sut;
            private Price _result;

            protected override void Given()
            {
                _dapperWrapper.Setup(s => s.QuerySingleAsync<PriceDto>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .ReturnsAsync(new PriceDto { ProductId = 1, Value = 10 });

                _sut = new PriceRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetPriceByProductIdAsync(1);
            }

            [Fact]
            public void Schould_Return_Price_By_ProductId()
            {
                Check.That(_result).IsNotNull();
            }

        }

    }

}

