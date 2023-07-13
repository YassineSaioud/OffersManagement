using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IPriceRepository
    {
        Task<Price> GetByProductIdAsync(int productId);
        Task<int> AddAsync(Price price);
        Task<int> UpdateAsync(Price price);
    }
}
