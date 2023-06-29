namespace OffersManagement.Domain.Entities
{
    public class Offer
    {
        public Offer(int id, Product? product)
        {
            Id = id;
            Product = product;
        }

        public int Id { get; set; }
        public Product? Product { get; set; }
    }
}
