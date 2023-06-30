using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public interface IOfferAdapter
    {
        IEnumerable<OfferModel> GetAll();
        void Create(OfferModel offer);
        void Update(OfferModel offer);
    }
}
