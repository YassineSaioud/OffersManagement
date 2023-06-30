using Dapper;
using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class PriceRepository
        : IPriceRepository
    {

        private readonly IDbConnection _dbConnection;

        public PriceRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Price GetPriceByProductId(int productId)
        {
            var sqlQuery = "SELECT * FROM price WHERE product_id=@product_id";
            var dbPrice = _dbConnection.QuerySingle(sqlQuery, new
            {
                product_id = productId
            });

            return new Price((int)dbPrice.product_id, dbPrice.value);
        }

        public void AddPrice(Price price)
        {
            var sqlQuery = "INSERT INTO price(product_id,value) VALUES (@product_id,@value)";
            _dbConnection.Execute(sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });
        }

        public void UpdatePrice(Price price)
        {
            var sqlQuery = "UPDATE price SET value=@value WHERE product_id=@product_id";
            _dbConnection.Execute(sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });
        }
    }
}
