using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferUpdateCommandHandler
    {
        Task<int> HandleAsync(Offer offer);
    }
}

