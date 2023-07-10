using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferService
    {
        Task<IEnumerable<Offer>> GetAllAsync();
        Task<int> CreateAsync(Offer offer);
        Task<int> UpdateAsync(Offer offer);
    }
}
