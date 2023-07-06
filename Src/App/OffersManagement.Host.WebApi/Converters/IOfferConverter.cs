using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public interface IOfferConverter
    {
        Offer Convert(OfferModel offerModel);
        IEnumerable<OfferModel> Convert(IEnumerable<Offer> offers);
    }
}

