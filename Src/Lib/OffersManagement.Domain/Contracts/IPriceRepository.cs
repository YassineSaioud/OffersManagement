using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IPriceRepository
    {
        Price GetPriceByProductId(int productId);
        void AddPrice(Price price);
        void UpdatePrice(Price price);
    }
}
