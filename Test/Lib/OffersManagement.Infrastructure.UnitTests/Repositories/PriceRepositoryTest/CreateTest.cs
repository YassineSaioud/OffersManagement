using Moq;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.PriceRepositoryTest
{
    public class CreateTest
    {
        public class Given_PriceRepository_When_Create_Price
               : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IDbConnection> _dbProvider = new();


            private PriceRepository _sut;
            private Price _priceToCreate;

            protected override void Given()
            {
                _priceToCreate = new Price(1, 20);

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .Verifiable();

                _sut = new PriceRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                await _sut.AddAsync(_priceToCreate);
            }

            [Fact]
            public void Schould_Create_Price_For_Product()
            {
                _dapperWrapper.Verify(s => s.ExecuteAsync(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()), Times.Once);
            }

        }

    }
}
