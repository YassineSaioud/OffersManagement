using Moq;
using NFluent;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.ProductRepositoryTest
{
    public class GetAllTest
    {

        public class Given_ProductRepository_When_GetAllOffers
            : Given_When_Then_Test
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IPriceRepository> _priceRepository = new();
            private Mock<IStockRepository> _stockRepository = new();

            private ProductRepository _sut;
            private IEnumerable<Product> _result;
            private List<ProductDto> _productDtos;

            protected override void Given()
            {
                _productDtos = new List<ProductDto> {
                                  new ProductDto { Id = 1, Brand = "Sarenza", Name="T-Shirt", Size ="S" },
                                  new ProductDto { Id = 2 , Brand = "Sarenza", Name="T-Shirt", Size ="M"},
                                  new ProductDto { Id = 3 , Brand = "Sarenza", Name="T-Shirt", Size ="L"}
                              };

                _dapperWrapper.Setup(s => s.Query<ProductDto>(It.IsAny<string>(), It.IsAny<object>()))
                              .Returns(_productDtos);

                _sut = new ProductRepository(_dapperWrapper.Object, _priceRepository.Object, _stockRepository.Object);
            }

            protected override void When()
            {
                _result = _sut.GetAll();
            }

            [Fact]
            public void Should_Return_All_Products()
            {
                Check.That(_result.Any()).IsTrue();
            }


        }

    }
}
