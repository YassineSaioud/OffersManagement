using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IStockRepository
    {
        Task<Stock> GetStockByProductIdAsync(int productId);
        Task<int> AddStockAsync(Stock stock);
        Task<int> UpdateStockAsync(Stock stock);
    }
}

