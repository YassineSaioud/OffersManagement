using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferCommandReader
    {
        IEnumerable<Offer> GetOffers();
    }
}
