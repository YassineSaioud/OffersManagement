using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IProductRepository
    {
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}

