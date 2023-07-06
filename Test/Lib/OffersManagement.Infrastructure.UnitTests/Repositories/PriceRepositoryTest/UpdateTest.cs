using Moq;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.PriceRepositoryTest
{
    public class UpdateTest
    {

        public class Given_PriceRepository_When_Update_Price
              : Given_When_Then_Test
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();


            private PriceRepository _sut;
            private Price _priceToUpdate;

            protected override void Given()
            {
                _priceToUpdate = new Price(1, 20);

                _dapperWrapper.Setup(s => s.Execute(It.IsAny<string>(), It.IsAny<object>()))
                              .Verifiable();

                _sut = new PriceRepository(_dapperWrapper.Object);
            }

            protected override void When()
            {
                _sut.UpdatePrice(_priceToUpdate);
            }

            [Fact]
            public void Schould_Update_Price_For_Product()
            {
                _dapperWrapper.Verify(s => s.Execute(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            }

        }

    }
}
