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

        public Price GetPriceByProductId(int productId)
        {
            var sqlQuery = "SELECT product_id,value FROM price WHERE product_id=@product_id";
            var dbPrice = _dapperWrapper.QuerySingle<PriceDto>(sqlQuery, new
            {
                product_id = productId
            });

            return new Price((int)dbPrice.ProductId, dbPrice.Value);
        }

        public void AddPrice(Price price)
        {
            var sqlQuery = "INSERT INTO price(product_id,value) VALUES (@product_id,@value)";
            _dapperWrapper.Execute(sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });
        }

        public void UpdatePrice(Price price)
        {
            var sqlQuery = "UPDATE price SET value=@value WHERE product_id=@product_id";
            _dapperWrapper.Execute(sqlQuery, new
            {
                product_id = price.ProductId,
                value = price.Value
            });
        }
    }
}
