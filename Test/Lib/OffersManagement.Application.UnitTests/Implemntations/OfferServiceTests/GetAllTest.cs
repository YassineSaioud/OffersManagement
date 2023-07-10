using Moq;
using NFluent;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.UnitTests.Implemntations.OfferServiceTests
{
    public class GetAllTest
    {
        public class Given_OfferUpdateCommand_When_Get_All_Offers
            : Given_When_Then_Test_Async
        {
            private readonly Mock<IProductRepository> _productRepository = new();

            private OfferService _sut;
            private IEnumerable<Offer> _result;

            private List<Product> _products;

            protected override void Given()
            {
                _products = new List<Product>
                {
                    new Product(1, "T-Shirt", "Sarenza", "S", new Price(1, 20), new Stock(1, 50)),
                    new Product(2, "T-Shirt", "Sarenza", "M", new Price(2, 25), new Stock(2, 50)),
                    new Product(3, "T-Shirt", "Sarenza", "L", new Price(3, 30), new Stock(3, 50))
                };

                _productRepository.Setup(s => s.GetAllAsync())
                                  .ReturnsAsync(_products);

                _sut = new OfferService(_productRepository.Object);
            }

            protected override async Task When()
            {
                _result = await _sut.GetAllAsync();
            }

            [Fact]
            public void Then_Should_Return_Offers()
            {
                Check.That(_result.Any()).IsTrue();
            }

        }
    }
}
