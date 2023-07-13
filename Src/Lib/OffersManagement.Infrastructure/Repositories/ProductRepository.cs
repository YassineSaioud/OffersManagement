using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class ProductRepository
        : DapperBase, IProductRepository
    {

        private readonly IDapperWrapper _dapperWrapper;
        private readonly IDbConnection _dbProvider;

        public ProductRepository(IDapperWrapper dapperWrapper,
                                 IDbConnection provider)
            : base(provider)
        {
            _dapperWrapper = dapperWrapper;
            _dbProvider = provider;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var productsResult = new List<Product>();

            var sqlQuery = "SELECT id,name,brand,size FROM product";
            var dbProducts = await _dapperWrapper.QueryAsync<ProductDto>(_dbProvider, sqlQuery);
            if (dbProducts is not null)
            {
                var products = from dbProduct in dbProducts
                               select new Product(dbProduct.Id, dbProduct.Name, dbProduct.Brand, dbProduct.Size);

                return products;
            }

            throw new ArgumentNullException(nameof(dbProducts));
        }

        public async Task<int> AddAsync(Product product)
        {
            var sqlQuery = "INSERT INTO product(id,name,brand,size) VALUES (@id,@name,@brand,@size)";
            var productResult = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
            {
                id = product.Id,
                name = product.Name,
                brand = product.Brand,
                size = product.Size
            });

            return productResult;

        }

        public async Task<int> UpdateAsync(Product product)
        {
            var sqlQuery = "UPDATE product SET name=@name,brand=@brand,size=@size WHERE id = @id";
            var productResult = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
            {
                id = product.Id,
                name = product.Name,
                brand = product.Brand,
                size = product.Size
            });

            return productResult;

        }

    }
}
