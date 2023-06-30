using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferGetQuery
    {
        IEnumerable<Offer> Handle();
    }
}
