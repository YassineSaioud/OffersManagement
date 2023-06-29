namespace OffersManagement.Domain.Entities
{
    public class Product
    {
        public Product(int id, string? name, string? brand, string? size, Price? price, Stock? stock)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Size = size;
            Price = price;
            Stock = stock;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Size { get; set; }
        public Price? Price { get; set; }
        public Stock? Stock { get; set; }
    }
}
