using OffersManagement.Domain.Contracts;

namespace OffersManagement.Host.WebApi
{
    public class OfferService
        : IOfferService
    {
        private readonly IOfferGetQueryHandler _offerGetQuery;
        private readonly IOfferCreateCommandHandler _offerCreateCommand;
        private readonly IOfferUpdateCommandHandler _offerUpdateCommand;
        private readonly IOfferConverter _offerConverter;

        public OfferService(IOfferConverter offerConverter,
                            IOfferGetQueryHandler offerGetQuery,
                            IOfferCreateCommandHandler offerCreateCommand,
                            IOfferUpdateCommandHandler offerUpdateCommand)
        {
            _offerConverter = offerConverter;
            _offerGetQuery = offerGetQuery;
            _offerCreateCommand = offerCreateCommand;
            _offerUpdateCommand = offerUpdateCommand;
        }

        public async Task<IEnumerable<OfferModel>> GetAllAsync()
        {
            var offers = await _offerGetQuery.HandleAsync();
            var offerModels = _offerConverter.Convert(offers);

            return offerModels;
        }

        public async Task<int> CreateAsync(OfferModel offerModel)
        {
            var offer = _offerConverter.Convert(offerModel);
            return await _offerCreateCommand.HandleAsync(offer);
        }

        public async Task<int> UpdateAsync(OfferModel offerModel)
        {
            var offer = _offerConverter.Convert(offerModel);
            return await _offerUpdateCommand.HandleAsync(offer);
        }

    }
}

