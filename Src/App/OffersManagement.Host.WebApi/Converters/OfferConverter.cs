using OffersManagement.Domain.Entities;

namespace OffersManagement.Host.WebApi
{
    public class OfferConverter
        : IOfferConverter
    {
        public Offer Convert(OfferModel offerModel)
        {
            if (offerModel is null)
            {
                throw new ArgumentNullException(nameof(offerModel), "Can not convert a empty offer.");
            }

            var price = new Price(offerModel.ProductId, offerModel.Price);
            var stock = new Stock(offerModel.ProductId, offerModel.Quantity);
            var product = new Product(offerModel.ProductId,
                                      offerModel.ProductName,
                                      offerModel.ProductBrand,
                                      offerModel.ProductSize);

            return new Offer(product, price, stock);
        }

        public IEnumerable<OfferModel> Convert(IEnumerable<Offer> offers)
        {
            if (!offers.Any())
            {
                throw new Exception("can not convert a empty list of offers.");
            }

            return from offer in offers
                   select new OfferModel(offer.Product.Id,
                                         offer.Product.Name,
                                         offer.Product.Brand,
                                         offer.Product.Size,
                                         offer.Price.Value,
                                         offer.Stock.Quantity
                                        );
        }
    }
}
