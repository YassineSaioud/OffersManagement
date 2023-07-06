using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public interface IOfferService
    {
        IEnumerable<OfferModel> GetAll();
        void Create(OfferModel offer);
        void Update(OfferModel offer);
    }
}
