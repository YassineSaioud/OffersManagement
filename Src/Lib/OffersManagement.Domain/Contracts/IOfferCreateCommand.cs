using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferCreateCommand
    {
        void Handle(Offer offer);
    }
}
