namespace OffersManagement.Domain.Entities
{
    public class Price
    {
        public Price(int productId, decimal value)
        {
            ProductId = productId;
            Value = value;
        }

        public int ProductId { get; set; }
        public decimal Value { get; set; }
    }
}
