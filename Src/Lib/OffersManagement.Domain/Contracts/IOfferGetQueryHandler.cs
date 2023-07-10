using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferGetQueryHandler
    {
        Task<IEnumerable<Offer>> HandleAsync();
    }
}
