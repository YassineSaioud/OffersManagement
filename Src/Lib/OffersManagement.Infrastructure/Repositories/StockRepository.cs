using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class StockRepository
        : DapperBase, IStockRepository
    {

        private readonly IDapperWrapper _dapperWrapper;
        private readonly IDbConnection _dbProvider;

        public StockRepository(IDapperWrapper dbConnection, IDbConnection dbProvider) : base(dbProvider)
        {
            _dapperWrapper = dbConnection;
            _dbProvider = dbProvider;
        }

        public async Task<Stock> GetStockByProductIdAsync(int productId)
        {
            var sqlQuery = $"SELECT product_id,quantity FROM stock WHERE product_id=@product_id";
            var dbStock = await _dapperWrapper.QuerySingleAsync<StockDto>(_dbProvider, sqlQuery, new
            {
                product_id = productId
            });

            if (dbStock is null)
            {
                throw new ArgumentNullException(nameof(dbStock));
            }

            return new Stock(dbStock.ProductId, dbStock.Quantity);
        }

        public async Task<int> AddStockAsync(Stock stock)
        {
            var sqlQuery = $"INSERT INTO stock(product_id,quantity) VALUES (@product_id,@quantity)";
            var result = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });

            return result;
        }

        public async Task<int> UpdateStockAsync(Stock stock)
        {
            var sqlQuery = "UPDATE stock SET quantity=@quantity WHERE product_id=@product_id";
            var result = await _dapperWrapper.ExecuteAsync(_dbProvider, sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });

            return result;
        }

    }
}
