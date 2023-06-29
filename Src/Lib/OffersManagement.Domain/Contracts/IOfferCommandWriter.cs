using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferCommandWriter
    {
        void AddOffer(Offer offer);
        void UpdaterOffer(Offer offer); 
    }
}
