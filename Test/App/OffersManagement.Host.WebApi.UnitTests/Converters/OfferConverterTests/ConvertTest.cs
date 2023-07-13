using NFluent;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi.UnitTests.Converters.OfferConverterTests
{
    public class ConvertTest
    {

        public class Given_OfferConverter_When_Convert_OffetModel_To_Offer_Domain
            : Given_When_Then_Test
        {
            private OfferConverter _sut;
            private Offer _result;

            private OfferModel offerModelToConvert;

            protected override void Given()
            {
                offerModelToConvert = new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20);
                _sut = new OfferConverter();
            }

            protected override void When()
            {
                _result = _sut.Convert(offerModelToConvert);
            }

            [Fact]
            public void Then_Should_Convert_To_Offer_Domain()
            {
                Check.That(_result).IsNotNull();
            }
        }

        public class Given_OfferConverter_When_Convert_List_Of_Offers_To_List_Of_Offers_Model
            : Given_When_Then_Test
        {
            private OfferConverter _sut;
            private IEnumerable<OfferModel> _result;

            private IEnumerable<Offer> _offers;

            protected override void Given()
            {
                _offers = new List<Offer>()
                {
                    new Offer(new Product(1, "T-Shirt", "Sarenza", "M"), new Price(1,30), new Stock(1,50)),
                    new Offer(new Product(2, "T-Shirt", "Sarenza", "L"), new Price(2,20), new Stock(1,100))
                };
                _sut = new OfferConverter();
            }

            protected override void When()
            {
                _result = _sut.Convert(_offers);
            }

            [Fact]
            public void Then_Should_Convert_To_Offers_Model()
            {
                Check.That(_result.Any()).IsTrue();
            }

        }
    }
}
