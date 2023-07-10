using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<int> AddProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
    }
}

