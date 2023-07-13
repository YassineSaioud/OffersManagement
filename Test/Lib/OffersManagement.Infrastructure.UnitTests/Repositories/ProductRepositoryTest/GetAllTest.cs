using Moq;
using NFluent;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure.UnitTests.Repositories.ProductRepositoryTest
{
    public class GetAllTest
    {

        public class Given_ProductRepository_When_GetAllOffers
            : Given_When_Then_Test_Async
        {
            private Mock<IDapperWrapper> _dapperWrapper = new();
            private Mock<IDbConnection> _dbProvider = new();

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

                _dapperWrapper.Setup(s => s.QueryAsync<ProductDto>(It.IsAny<IDbConnection>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>()))
                              .ReturnsAsync(_productDtos);

                _sut = new ProductRepository(_dapperWrapper.Object, _dbProvider.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetAllAsync();
            }

            [Fact]
            public void Should_Return_All_Products()
            {
                Check.That(_result.Any()).IsTrue();
            }


        }

    }
}
