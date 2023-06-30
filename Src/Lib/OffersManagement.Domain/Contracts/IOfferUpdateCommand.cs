using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferUpdateCommand
    {
        void Handle(Offer offer);
    }
}

