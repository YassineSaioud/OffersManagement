using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IPriceRepository
    {
        Task<Price> GetPriceByProductIdAsync(int productId);
        Task<int> AddPriceAsync(Price price);
        Task<int> UpdatePriceAsync(Price price);
    }
}
