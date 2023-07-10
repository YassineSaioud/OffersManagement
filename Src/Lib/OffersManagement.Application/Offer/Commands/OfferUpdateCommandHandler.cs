using OffersManagement.Domain.Contracts;

namespace OffersManagement.Application.Offer
{
    public class OfferUpdateCommandHandler
        : IOfferUpdateCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public OfferUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> HandleAsync(Domain.Entities.Offer offer) 
            => await _productRepository.UpdateProductAsync(offer.Product);
    }
}
