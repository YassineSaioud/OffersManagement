using OffersManagement.Domain.Contracts;

namespace OffersManagement.Host.WebApi
{
    public class OfferService
        : IOfferService
    {
        private readonly IOfferGetQuery _offerGetQuery;
        private readonly IOfferCreateCommand _offerCreateCommand;
        private readonly IOfferUpdateCommand _offerUpdateCommand;
        private readonly IOfferConverter _offerConverter;

        public OfferService(IOfferConverter offerConverter,
                            IOfferGetQuery offerGetQuery,
                            IOfferCreateCommand offerCreateCommand,
                            IOfferUpdateCommand offerUpdateCommand)
        {
            _offerConverter = offerConverter;
            _offerGetQuery = offerGetQuery;
            _offerCreateCommand = offerCreateCommand;
            _offerUpdateCommand = offerUpdateCommand;
        }

        public IEnumerable<OfferModel> GetAll()
        {
            var offers = _offerGetQuery.Handle();
            var offerModels = _offerConverter.Convert(offers);

            return offerModels;
        }

        public void Create(OfferModel offerModel)
        {
            var offer = _offerConverter.Convert(offerModel);
            _offerCreateCommand.Handle(offer);
        }

        public void Update(OfferModel offerModel)
        {
            var offer = _offerConverter.Convert(offerModel);
            _offerUpdateCommand.Handle(offer);
        }

    }
}

