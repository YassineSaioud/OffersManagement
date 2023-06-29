using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public interface IOfferAdapter
    {
        IEnumerable<OfferModel> GetOffers();
        void AddOffer(OfferModel offer);
        void UpdateOffer(OfferModel offer);
    }
}
