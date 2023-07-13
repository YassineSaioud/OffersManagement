using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application
{
    public class OfferService
        : IOfferService
    {

        private readonly IProductRepository _productRepository;

        public OfferService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            if (!products.Any())
            {
                throw new Exception("Empty result.");
            }

            return from product in products
                   select new Offer(product);
        }

        public async Task<int> CreateAsync(Offer offer)
        {
            if (offer == null)
            {
                throw new ArgumentNullException(nameof(offer), "Can not create a empty offer.");
            }

            var product = new Product(offer.Product.Id,
                                      offer.Product.Name,
                                      offer.Product.Brand,
                                      offer.Product.Size,
                                      offer.Product.Price,
                                      offer.Product.Stock);

            return await _productRepository.AddProductAsync(product);
        }



        public async Task<int> UpdateAsync(Offer offer)
        {
            if (offer == null)
            {
                throw new ArgumentNullException(nameof(offer), "Can not update empty offer.");
            }

            if (offer?.Product?.Id == default)
            {
                throw new ArgumentException(nameof(offer), "Can not update offer without id.");

            }

            var product = new Product(offer.Product.Id,
                                      offer.Product.Name,
                                      offer.Product.Brand,
                                      offer.Product.Size,
                                      offer.Product.Price,
                                      offer.Product.Stock);

            return await _productRepository.UpdateProductAsync(product);
        }
    }
}

