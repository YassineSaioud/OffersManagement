using OffersManagement.Domain.Entities;

namespace OffersManagement.Domain.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<int> AddAsync(Product product);
        Task<int> UpdateAsync(Product product);
    }
}

