namespace OffersManagement.Host.WebApi
{
    public record OfferModel(int ProductId,
                             string? ProductName,
                             string? ProductBrand,
                             string? ProductSize,
                             decimal Price,
                             int Quantity);
}