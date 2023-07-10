using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferCreateCommandHandler
    {
        Task<int> HandleAsync(Offer offer);
    }
}
