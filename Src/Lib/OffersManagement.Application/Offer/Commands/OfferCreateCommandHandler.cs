using OffersManagement.Domain.Contracts;

namespace OffersManagement.Application.Offer
{
    public class OfferCreateCommandHandler
        : IOfferCreateCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public OfferCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> HandleAsync(Domain.Entities.Offer offer) 
            => await _productRepository.AddProductAsync(offer.Product);
    }
}
