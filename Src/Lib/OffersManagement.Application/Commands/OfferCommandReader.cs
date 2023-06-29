using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application.Commands
{
    public class OfferCommandReader
        : IOfferCommandReader
    {
        public IEnumerable<Offer> GetOffers()
        {
            return new List<Offer>()
            {
                
            };
        }
    }
}
