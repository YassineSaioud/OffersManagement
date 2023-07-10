using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Infrastructure
{
    public class StockRepository
        : IStockRepository
    {

        private readonly IDapperWrapper _dapperWrapper;

        public StockRepository(IDapperWrapper dapperWrapper)
        {
            _dapperWrapper = dapperWrapper;
        }

        public async Task<Stock> GetStockByProductIdAsync(int productId)
        {
            var sqlQuery = $"SELECT product_id,quantity FROM stock WHERE product_id=@product_id";
            var dbStock = await _dapperWrapper.QuerySingleAsync<StockDto>(sqlQuery, new
            {
                product_id = productId
            });

            return new Stock(dbStock.ProductId, dbStock.Quantity);
        }

        public async Task<int> AddStockAsync(Stock stock)
        {
            var sqlQuery = $"INSERT INTO stock(product_id,quantity) VALUES (@product_id,@quantity)";
            var result = await _dapperWrapper.ExecuteAsync(sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });

            return result;
        }

        public async Task<int> UpdateStockAsync(Stock stock)
        {
            var sqlQuery = "UPDATE stock SET quantity=@quantity WHERE product_id=@product_id";
            var result = await _dapperWrapper.ExecuteAsync(sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });
            return result;
        }

    }
}
