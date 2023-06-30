using Dapper;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class StockRepository
        : IStockRepository
    {

        private readonly IDbConnection _dbConnection;

        public StockRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Stock GetStockByProductId(int productId)
        {
            var sqlQuery = $"SELECT * FROM stock WHERE product_id=@product_id";
            var dbStock = _dbConnection.QuerySingle(sqlQuery, new
            {
                product_id = productId
            });

            return new Stock((int)dbStock.product_id, dbStock.quantity);
        }

        public void AddStock(Stock stock)
        {
            var sqlQuery = $"INSERT INTO stock(product_id,quantity) VALUES (@product_id,@quantity)";
            _dbConnection.Execute(sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });
        }

        public void UpdateStock(Stock stock)
        {
            var sqlQuery = "UPDATE stock SET quantity=@quantity WHERE product_id=@product_id";
            _dbConnection.Execute(sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });
        }

    }
}
