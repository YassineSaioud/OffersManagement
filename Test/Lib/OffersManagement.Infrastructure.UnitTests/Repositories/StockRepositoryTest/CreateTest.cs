using Moq;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.StockRepositoryTest
{
    public class CreateTest
    {
        public class Given_StockRepository_When_Create_Stock
               : Given_When_Then_Test
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();


            private StockRepository _sut;
            private Stock _priceToCreate;

            protected override void Given()
            {
                _priceToCreate = new Stock(1, 20);

                _dapperWrapper.Setup(s => s.Execute(It.IsAny<string>(), It.IsAny<object>()))
                              .Verifiable();

                _sut = new StockRepository(_dapperWrapper.Object);
            }

            protected override void When()
            {
                _sut.AddStock(_priceToCreate);
            }

            [Fact]
            public void Schould_Create_Stock_For_Product()
            {
                _dapperWrapper.Verify(s => s.Execute(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            }

        }

    }
}
