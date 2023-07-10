using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure
{
    public class PriceRepository
        : IPriceRepository
    {

        private readonly IDapperWrapper _dapperWrapper;

        public PriceRepository(IDapperWrapper dbConnection)
        {
            _dapperWrapper = dbConnection;
        }

        public async Task<Price> GetPriceByProductIdAsync(int productId)
        {
            var sqlQuery = "SELECT product_id,value FROM price WHERE product_id=@product_id";
            var dbPrice = await _dapperWrapper.QuerySingleAsync<PriceDto>(sqlQuery, new
            {
                product_id = productId
            });

            return new Price((int)dbPrice.ProductId, dbPrice.Value);
        }

        public async Task<int> AddPriceAsync(Price price)
        {
            var sqlQuery = "INSERT INTO price(product_id,value) VALUES (@product_id,@value)";
            var priceResult = await _dapperWrapper.ExecuteAsync(sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });

            return priceResult;
        }

        public async Task<int> UpdatePriceAsync(Price price)
        {
            var sqlQuery = "UPDATE price SET value=@value WHERE product_id=@product_id";
            var proceResult = await _dapperWrapper.ExecuteAsync(sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });
            return proceResult;
        }
    }
}
