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
            return from product in products
                   select new Offer(product);
        }

        public async Task<int> CreateAsync(Offer offer)
        {
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

