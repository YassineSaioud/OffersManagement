using Moq;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.PriceRepositoryTest
{
    public class CreateTest
    {
        public class Given_PriceRepository_When_Create_Price
               : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();


            private PriceRepository _sut;
            private Price _priceToCreate;

            protected override void Given()
            {
                _priceToCreate = new Price(1, 20);

                _dapperWrapper.Setup(s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                              .Verifiable();

                _sut = new PriceRepository(_dapperWrapper.Object);
            }

            protected override async Task When()
            {
                await _sut.AddPriceAsync(_priceToCreate);
            }

            [Fact]
            public void Schould_Create_Price_For_Product()
            {
                _dapperWrapper.Verify(s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            }

        }

    }
}
