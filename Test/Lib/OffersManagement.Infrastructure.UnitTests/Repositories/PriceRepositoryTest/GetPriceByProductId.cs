using Moq;
using NFluent;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.PriceRepositoryTest
{
    public class GetPriceByProductId
    {

        public class Given_PriceRepository_When_GetPriceByProduct
            : Given_When_Then_Test
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();


            private PriceRepository _sut;
            private Price _result;

            protected override void Given()
            {
                _dapperWrapper.Setup(s => s.QuerySingle<PriceDto>(It.IsAny<string>(), It.IsAny<object>()))
                              .Returns(new PriceDto { ProductId = 1, Value = 10 });

                _sut = new PriceRepository(_dapperWrapper.Object);
            }

            protected override void When()
            {
                _result = _sut.GetPriceByProductId(1);
            }

            [Fact]
            public void Schould_Return_Price_By_ProductId()
            {
                Check.That(_result).IsNotNull();
            }

        }

    }

}

