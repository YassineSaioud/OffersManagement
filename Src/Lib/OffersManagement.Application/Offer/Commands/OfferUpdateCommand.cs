using OffersManagement.Domain.Contracts;

namespace OffersManagement.Application.Offer
{
    public class OfferUpdateCommand
        : IOfferUpdateCommand
    {
        private readonly IProductRepository _productRepository;

        public OfferUpdateCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Handle(Domain.Entities.Offer offer) 
            => _productRepository.UpdateProduct(offer.Product);
    }
}
