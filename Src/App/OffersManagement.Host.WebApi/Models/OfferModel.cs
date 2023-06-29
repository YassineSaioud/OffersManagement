namespace OffersManagement.Host.WebApi
{
    public class OfferModel
    {
        public OfferModel(int productId,
                          string? productName,
                          string? productBrand,
                          string? productSize,
                          decimal price,
                          int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductBrand = productBrand;
            ProductSize = productSize;
            Price = price;
            Quantity = quantity;

        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductBrand { get; set; }
        public string? ProductSize { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}