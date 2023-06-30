using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}

