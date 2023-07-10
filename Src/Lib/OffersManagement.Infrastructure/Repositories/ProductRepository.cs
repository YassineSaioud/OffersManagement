using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure
{
    public class ProductRepository
        : IProductRepository
    {
        private const int SuccessDbExecute = 1;
        private readonly IDapperWrapper _dapperWrapper;
        private readonly IPriceRepository _priceRepository;
        private readonly IStockRepository _stockRepository;

        public ProductRepository(IDapperWrapper dapperWrapper,
                                 IPriceRepository priceRepository,
                                 IStockRepository stockRepository)
        {
            _dapperWrapper = dapperWrapper;
            _priceRepository = priceRepository;
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var productsResult = new List<Product>();

            var sqlQuery = "SELECT * FROM product";
            var dbProducts = await _dapperWrapper.QueryAsync<ProductDto>(sqlQuery);
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
            var sqlQuery = "INSERT INTO product(id,name,brand,size) VALUES (@id,@name,@brand,@size)";
            var productResult = await _dapperWrapper.ExecuteAsync(sqlQuery, new
            {
                id = product.Id,
                name = product.Name,
                brand = product.Brand,
                size = product.Size
            });

            var priceResult = await _priceRepository.AddPriceAsync(product.Price);
            var stockResult = await _stockRepository.AddStockAsync(product.Stock);

            if (productResult != SuccessDbExecute)
            {
                throw new Exception("Product Add Not executed.");
            }

            if (priceResult != SuccessDbExecute)
            {
                throw new Exception("Price  Update Not executed.");
            }

            if (stockResult != SuccessDbExecute)
            {
                throw new Exception("Stock  Update Not executed.");
            }

            return productResult;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var sqlQuery = "UPDATE product SET name=@name,brand=@brand,size=@size WHERE id = @id";
            var productResult = await _dapperWrapper.ExecuteAsync(sqlQuery, new
            {
                id = product.Id,
                name = product.Name,
                brand = product.Brand,
                size = product.Size
            });
            var priceResult = await _priceRepository.UpdatePriceAsync(product.Price);
            var stockResult = await _stockRepository.UpdateStockAsync(product.Stock);

            if (productResult != SuccessDbExecute)
            {
                throw new Exception("Product Update Not executed.");
            }

            if (priceResult != SuccessDbExecute)
            {
                throw new Exception("Price  Update Not executed.");
            }

            if (stockResult != SuccessDbExecute)
            {
                throw new Exception("Stock  Update Not executed.");
            }

            return productResult;
        }
    }
}
