namespace OffersManagement.Domain.Entities
{
    public class Offer
    {
        public Offer(Product? product)
        {
            Product = product;
        }

        public Product? Product { get; set; }
    }
}
