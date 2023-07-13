using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class ProductRepository
        : DapperBase, IProductRepository
    {

        private readonly IDapperWrapper _dapperWrapper;
        private readonly IPriceRepository _priceRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IDbConnection _dbProvider;

        public ProductRepository(IDapperWrapper dapperWrapper,
                                 IPriceRepository priceRepository,
                                 IStockRepository stockRepository,
                                 IDbConnection provider)
            : base(provider)
        {
            _dapperWrapper = dapperWrapper;
            _priceRepository = priceRepository;
            _stockRepository = stockRepository;
            _dbProvider = provider;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var productsResult = new List<Product>();

            var sqlQuery = "SELECT * FROM product";
            var dbProducts = await _dapperWrapper.QueryAsync<ProductDto>(_dbProvider, sqlQuery);
            if (dbProducts is null)
            {
                throw new ArgumentNullException(nameof(dbProducts));
            }

            foreach (var dbProduct in dbProducts)
            {
                var price = await _priceRepository.GetPriceByProductIdAsync(dbProduct.Id);
                var stock = await _stockRepository.GetStockByProductIdAsync(dbProduct.Id);
                productsResult.Add(new Product(dbProduct.Id,
                                       dbProduct.Name,
                                       dbProduct.Brand,
                                       dbProduct.Size,
                                       price,
                                       stock
                                   ));
            }

            return productsResult;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _dbProvider.Open();

            using var transaction = _dbProvider.BeginTransaction();
            try
            {
                var sqlQuery = "INSERT INTO product(id,name,brand,size) VALUES (@id,@name,@brand,@size)";
                var productResult = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
                {
                    id = product.Id,
                    name = product.Name,
                    brand = product.Brand,
                    size = product.Size
                }, transaction);

                var priceResult = await _priceRepository.AddPriceAsync(product.Price);
                var stockResult = await _stockRepository.AddStockAsync(product.Stock);

                transaction.Commit();              

                return productResult;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _dbProvider.Dispose();
            }

        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            _dbProvider.Open();
            using var transaction = _dbProvider.BeginTransaction();
            try
            {
                var sqlQuery = "UPDATE product SET name=@name,brand=@brand,size=@size WHERE id = @id";
                var productResult = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
                {
                    id = product.Id,
                    name = product.Name,
                    brand = product.Brand,
                    size = product.Size
                }, transaction);
                var priceResult = await _priceRepository.UpdatePriceAsync(product.Price);
                var stockResult = await _stockRepository.UpdateStockAsync(product.Stock);

                transaction.Commit();               

                return productResult;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _dbProvider.Dispose();
            }

        }
    }
}
