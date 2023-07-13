using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetAllAsync();
        Task<int> AddAsync(Offer offer);
        Task<int> UpdateAsync(Offer offer);
    }
}
