using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public class OfferConverter
        : IOfferConverter
    {
        public Offer Convert(OfferModel offerModel)
        {
            var price = new Price(offerModel.ProductId, offerModel.Price);
            var stock = new Stock(offerModel.ProductId, offerModel.Quantity);
            var product = new Product(offerModel.ProductId,
                                      offerModel.ProductName,
                                      offerModel.ProductBrand,
                                      offerModel.ProductSize,
                                      price,
                                      stock);

            return new Offer(product);
        }

        public IEnumerable<OfferModel> Convert(IEnumerable<Offer> offers)
        {
            return from offer in offers
                   select new OfferModel(offer.Product.Id,
                                         offer.Product.Name,
                                         offer.Product.Brand,
                                         offer.Product.Size,
                                         offer.Product.Price.Value,
                                         offer.Product.Stock.Quantity
                                        );
        }
    }
}
