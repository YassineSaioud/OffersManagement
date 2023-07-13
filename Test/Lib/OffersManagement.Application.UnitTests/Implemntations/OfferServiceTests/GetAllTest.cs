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
            private readonly Mock<IOfferRepository> _offerRepository = new();

            private OfferService _sut;
            private IEnumerable<Offer> _result;

            private List<Offer> _offers;

            protected override void Given()
            {
                _offers = new List<Offer>
                {
                    new Offer(new Product(1, "T-Shirt", "Sarenza", "S"), new Price(1, 20), new Stock(1, 50)),
                    new Offer(new Product(1, "T-Shirt", "Sarenza", "M"), new Price(1, 20), new Stock(1, 50)),
                    new Offer(new Product(1, "T-Shirt", "Sarenza", "L"), new Price(1, 20), new Stock(1, 50))
                };

                _offerRepository.Setup(s => s.GetAllAsync())
                                  .ReturnsAsync(_offers);

                _sut = new OfferService(_offerRepository.Object);
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
