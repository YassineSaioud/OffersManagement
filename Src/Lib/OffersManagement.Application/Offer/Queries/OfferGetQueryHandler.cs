using OffersManagement.Domain.Contracts;

namespace OffersManagement.Application.Offer
{
    public class OfferGetQueryHandler
        : IOfferGetQueryHandler

    {
        private readonly IProductRepository _productRepository;

        public OfferGetQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Offer>> HandleAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return from product in products
                   select new Domain.Entities.Offer(product);
        }
    }
}
