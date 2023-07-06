namespace OffersManagement.Domain.Entities
{
    public record Product(int Id,
                          string? Name,
                          string? Brand,
                          string? Size,
                          Price? Price,
                          Stock? Stock);

}
