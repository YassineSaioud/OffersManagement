using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IStockRepository
    {
        Stock GetStockByProductId(int productId);
        void AddStock(Stock stock);
        void UndoStock(Stock stock);
    }
}

