using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public class OfferConverter
        : IOfferConverter
    {
        public Offer Convert(OfferModel offerModel)
        {          
            return null;
        }

        public IEnumerable<OfferModel> Convert(IEnumerable<Offer> offers)
        {
            return null;
        }
    }
}
