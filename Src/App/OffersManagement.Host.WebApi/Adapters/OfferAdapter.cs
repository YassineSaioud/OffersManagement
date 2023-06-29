using OffersManagement.Domain.Contracts;

namespace OffersManagement.Host.WebApi
{
    public class OfferAdapter
        : IOfferAdapter
    {
        private readonly IOfferCommandReader _offerCommandReader;
        private readonly IOfferCommandWriter _offerCommandWriter;
        private readonly IOfferConverter _offerConverter;

        public OfferAdapter(IOfferCommandReader offerCommandReader,
                            IOfferCommandWriter offerCommandWriter,
                            IOfferConverter offerConverter)
        {
            _offerCommandReader = offerCommandReader;
            _offerCommandWriter = offerCommandWriter;
            _offerConverter = offerConverter;
        }

        public IEnumerable<OfferModel> GetOffers()
        {
            var offers = _offerCommandReader.GetOffers();
            var offerModels = _offerConverter.Convert(offers);

            return offerModels;
        }

        public void AddOffer(OfferModel offerModel)
        {
            var offer = _offerConverter.Convert(offerModel);
            _offerCommandWriter.AddOffer(offer);
        }

        public void UpdateOffer(OfferModel offerModel)
        {
            var offer = _offerConverter.Convert(offerModel);
            _offerCommandWriter.UpdaterOffer(offer);
        }

    }
}

