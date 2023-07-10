using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferModel>> GetAllAsync();
        Task<int> CreateAsync(OfferModel offer);
        Task<int> UpdateAsync(OfferModel offer);
    }
}
