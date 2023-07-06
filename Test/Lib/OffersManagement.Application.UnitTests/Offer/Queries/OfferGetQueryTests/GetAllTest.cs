using Moq;
using NFluent;
using OffersManagement.Application.Offer;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.UnitTests.Offer.Queries.OfferGetQueryTests
{
    public class GetAllTest
    {
        public class Given_OfferUpdateCommand_When_Get_All_Offers
            : Given_When_Then_Test
        {
            private readonly Mock<IProductRepository> _productRepository = new();

            private OfferGetQuery _sut;
            private IEnumerable<Domain.Entities.Offer> _result;

            private List<Product> _products;

            protected override void Given()
            {
                _products = new List<Product>
                {
                    new Product(1, "T-Shirt", "Sarenza", "S", new Price(1, 20), new Stock(1, 50)),
                    new Product(2, "T-Shirt", "Sarenza", "M", new Price(2, 25), new Stock(2, 50)),
                    new Product(3, "T-Shirt", "Sarenza", "L", new Price(3, 30), new Stock(3, 50))
                };

                _productRepository.Setup(s => s.GetAll())
                                  .Returns(_products);

                _sut = new OfferGetQuery(_productRepository.Object);
            }

            protected override void When()
            {
                _result = _sut.Handle();
            }

            [Fact]
            public void Then_Should_Return_Offers()
            {
                Check.That(_result.Any()).IsTrue();
            }

        }
    }
}
