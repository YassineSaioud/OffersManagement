using Moq;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi.UnitTests.Services
{
    public class SutBuilder
    {
        private readonly Mock<IOfferGetQuery> _offerGetQuery = new();
        private readonly Mock<IOfferCreateCommand> _offerCreateCommand = new();
        private readonly Mock<IOfferUpdateCommand> _offerUpdateCommand = new();
        private readonly Mock<IOfferConverter> _offerConverter = new();

        private readonly List<Offer> _offers = new()
        {
            new Offer(new Product(1, "T-Shirt", "Sarenza", "M", null, null)),
            new Offer(new Product(2, "T-Shirt", "Sarenza", "L", null, null))
        };

        private readonly List<OfferModel> _offersModels = new()
        {
            new OfferModel(1, "T-Shirt", "Sarenza", "M", 50, 20),
            new OfferModel(2, "T-Shirt", "Sarenza", "L", 40, 70)
        };

        public SutBuilder WithHandleGetQuery()
        {
            _offerGetQuery.Setup(o => o.Handle())
                          .Returns(_offers);

            return this;
        }

        public SutBuilder WithHandleCreateCommand()
        {
            _offerCreateCommand.Setup(o => o.Handle(_offers.FirstOrDefault()));

            return this;
        }

        public SutBuilder WithHandleUpdateCommand()
        {
            _offerUpdateCommand.Setup(o => o.Handle(_offers.FirstOrDefault()));

            return this;
        }

        public SutBuilder WithConvertToOffersModels()
        {
            _offerConverter.Setup(o => o.Convert(_offers))
                           .Returns(_offersModels);

            return this;
        }

        public SutBuilder WithConvertToOffer()
        {
            _offerConverter.Setup(o => o.Convert(_offersModels.FirstOrDefault()))
                           .Returns(_offers.FirstOrDefault()); ;

            return this;
        }

        public SutBuilder VerifyGetQueryIsHandled()
        {
            _offerGetQuery.Verify(o => o.Handle(), Times.Once);

            return this;
        }

        public SutBuilder VerifyCreateCommandIsHandled()
        {
            _offerCreateCommand.Verify(o => o.Handle(_offers.FirstOrDefault()), Times.Once);

            return this;
        }

        public SutBuilder VerifyUpdateCommandIsHandled()
        {
            _offerUpdateCommand.Verify(o => o.Handle(_offers.FirstOrDefault()), Times.Once);

            return this;
        }

        public SutBuilder VerifyOffersModelsIsConverted()
        {
            _offerConverter.Verify(o => o.Convert(_offers), Times.Once);

            return this;
        }

        public SutBuilder VerifyOfferIsConverted()
        {
            _offerConverter.Verify(o => o.Convert(_offersModels.FirstOrDefault()));

            return this;
        }


        public OfferService Build()
        {
            return new OfferService(_offerConverter.Object,
                                    _offerGetQuery.Object,
                                    _offerCreateCommand.Object,
                                    _offerUpdateCommand.Object);
        }

    }
}
