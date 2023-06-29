namespace OffersManagement.Domain.Entities
{
    public class Stock
    {
        public Stock(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
