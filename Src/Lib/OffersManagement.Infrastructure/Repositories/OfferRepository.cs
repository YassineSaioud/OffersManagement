using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class OfferRepository
        : DapperBase, IOfferRepository
    {

        private readonly IDapperWrapper _dapperWrapper;
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IDbConnection _dbProvider;

        public OfferRepository(IDapperWrapper dapperWrapper,
                               IProductRepository productRepository,
                               IPriceRepository priceRepository,
                               IStockRepository stockRepository,
                               IDbConnection provider)
            : base(provider)
        {
            _dapperWrapper = dapperWrapper;
            _priceRepository = priceRepository;
            _stockRepository = stockRepository;
            _dbProvider = provider;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            var offers = new List<Offer>();

            var products = await _productRepository.GetAllAsync();
            foreach (var product in products)
            {
                var price = await _priceRepository.GetByProductIdAsync(product.Id);
                var stock = await _stockRepository.GetByProductIdAsync(product.Id);

                offers.Add(new Offer(product, price, stock));
            }

            return offers;
        }

        public async Task<int> AddAsync(Offer offer)
        {
            _dbProvider.Open();

            using var transaction = _dbProvider.BeginTransaction();
            try
            {
                var sqlQuery = "INSERT INTO product(id,name,brand,size) VALUES (@id,@name,@brand,@size)";

                var productAddTask = _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
                {
                    id = offer.Product.Id,
                    name = offer.Product.Name,
                    brand = offer.Product.Brand,
                    size = offer.Product.Size
                }, transaction);
                var priceAddTask = _priceRepository.AddAsync(offer.Price);
                var stockAddTask = _stockRepository.AddAsync(offer.Stock);

                var result = await Task.WhenAll(productAddTask, priceAddTask, stockAddTask);

                transaction.Commit();

                return result.LastOrDefault();

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

        public async Task<int> UpdateAsync(Offer offer)
        {
            _dbProvider.Open();

            using var transaction = _dbProvider.BeginTransaction();
            try
            {
                var sqlQuery = "UPDATE product SET name=@name,brand=@brand,size=@size WHERE id = @id";

                var productUpdateTask = _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
                {
                    id = offer.Product.Id,
                    name = offer.Product.Name,
                    brand = offer.Product.Brand,
                    size = offer.Product.Size
                }, transaction);
                var priceUpdateTask = _priceRepository.UpdateAsync(offer.Price);
                var stockUpdateTask = _stockRepository.UpdateAsync(offer.Stock);

                var result = await Task.WhenAll(productUpdateTask, priceUpdateTask, stockUpdateTask);

                transaction.Commit();

                return result.LastOrDefault();
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
