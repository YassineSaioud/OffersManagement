using Dapper;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

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

        public Stock GetStockByProductId(int productId)
        {
            var sqlQuery = $"SELECT product_id,quantity FROM stock WHERE product_id=@product_id";
            var dbStock = _dapperWrapper.QuerySingle<StockDto>(sqlQuery, new
            {
                product_id = productId
            });

            return new Stock(dbStock.ProductId, dbStock.Quantity);
        }

        public void AddStock(Stock stock)
        {
            var sqlQuery = $"INSERT INTO stock(product_id,quantity) VALUES (@product_id,@quantity)";
            _dapperWrapper.Execute(sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });
        }

        public void UpdateStock(Stock stock)
        {
            var sqlQuery = "UPDATE stock SET quantity=@quantity WHERE product_id=@product_id";
            _dapperWrapper.Execute(sqlQuery, new
            {
                product_id = stock.ProductId,
                quantity = stock.Quantity
            });
        }

    }
}
