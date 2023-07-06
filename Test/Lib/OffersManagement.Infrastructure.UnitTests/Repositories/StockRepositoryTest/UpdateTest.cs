using Moq;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.StockRepositoryTest
{
    public class UpdateTest
    {

        public class Given_StockRepository_When_Update_Stock
              : Given_When_Then_Test
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();


            private StockRepository _sut;
            private Stock _stockToUpdate;

            protected override void Given()
            {
                _stockToUpdate = new Stock(1, 20);

                _dapperWrapper.Setup(s => s.Execute(It.IsAny<string>(), It.IsAny<object>()))
                              .Verifiable();

                _sut = new StockRepository(_dapperWrapper.Object);
            }

            protected override void When()
            {
                _sut.UpdateStock(_stockToUpdate);
            }

            [Fact]
            public void Schould_Update_Stock_For_Product()
            {
                _dapperWrapper.Verify(s => s.Execute(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            }

        }

    }
}
