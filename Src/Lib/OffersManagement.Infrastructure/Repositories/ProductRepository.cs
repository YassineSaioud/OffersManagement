using Dapper;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class ProductRepository
        : IProductRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IPriceRepository _priceRepository;
        private readonly IStockRepository _stockRepository;

        public ProductRepository(IDbConnection dbConnection,
                                 IPriceRepository priceRepository,
                                 IStockRepository stockRepository)
        {
            _dbConnection = dbConnection;
            _priceRepository = priceRepository;
            _stockRepository = stockRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            var sqlQuery = "SELECT * FROM product";
            var dbProducts = _dbConnection.Query(sqlQuery);
            if (dbProducts is not null)
            {
                return
                    from dbProduct in dbProducts
                    select new Product(dbProduct.id,
                                       dbProduct.name,
                                       dbProduct.brand,
                                       dbProduct.size,
                                       _priceRepository.GetPriceByProductId(dbProduct.id),
                                       _stockRepository.GetStockByProductId(dbProduct.id)
                                       );
            }

            return Enumerable.Empty<Product>();
        }

        public void AddProduct(Product product)
        {
            var sqlQuery = "INSERT INTO product(id,name,brand,size) VALUES (@id,@name,@brand,@size)";
            _dbConnection.Execute(sqlQuery, new
            {
                id = product.Id,
                name = product.Name,
                brand = product.Brand,
                size = product.Size
            });
            _priceRepository.AddPrice(product.Price);
            _stockRepository.AddStock(product.Stock);
        }

        public void UpdateProduct(Product product)
        {
            var sqlQuery = "UPDATE product SET name=@name,brand=@brand,size=@size WHERE id = @id";
            _dbConnection.Execute(sqlQuery, new
            {
                id = product.Id,
                name = product.Name,
                brand = product.Brand,
                size = product.Size
            });
            _priceRepository.UpdatePrice(product.Price);
            _stockRepository.UpdateStock(product.Stock);
        }
    }
}
