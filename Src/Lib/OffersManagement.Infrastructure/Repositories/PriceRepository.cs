using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class PriceRepository
        : DapperBase, IPriceRepository
    {

        private readonly IDapperWrapper _dapperWrapper;
        private readonly IDbConnection _dbProvider;

        public PriceRepository(IDapperWrapper dbConnection, IDbConnection dbProvider)
            : base(dbProvider)
        {
            _dapperWrapper = dbConnection;
            _dbProvider = dbProvider;
        }

        public async Task<Price> GetPriceByProductIdAsync(int productId)
        {
            var sqlQuery = "SELECT product_id,value FROM price WHERE product_id=@product_id";
            var dbPrice = await _dapperWrapper.QuerySingleAsync<PriceDto>(_dbProvider, sqlQuery, new
            {
                product_id = productId
            });

            if (dbPrice is null)
            {
                throw new ArgumentNullException(nameof(dbPrice));
            }

            return new Price((int)dbPrice.ProductId, dbPrice.Value);
        }

        public async Task<int> AddPriceAsync(Price price)
        {
            var sqlQuery = "INSERT INTO price(product_id,value) VALUES (@product_id,@value)";
            var priceResult = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });
  
            return priceResult;
        }

        public async Task<int> UpdatePriceAsync(Price price)
        {
            var sqlQuery = "UPDATE price SET value=@value WHERE product_id=@product_id";
            var priceResult = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });          

            return priceResult;
        }
    }
}
