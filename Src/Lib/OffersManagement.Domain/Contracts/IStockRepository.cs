using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IStockRepository
    {
        Task<Stock> GetByProductIdAsync(int productId);
        Task<int> AddAsync(Stock stock);
        Task<int> UpdateAsync(Stock stock);
    }
}

