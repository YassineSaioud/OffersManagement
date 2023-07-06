using OffersManagement.Domain.Contracts;

namespace OffersManagement.Application.Offer
{
    public class OfferCreateCommand
        : IOfferCreateCommand
    {
        private readonly IProductRepository _productRepository;

        public OfferCreateCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Handle(Domain.Entities.Offer offer) 
            => _productRepository.AddProduct(offer.Product);
    }
}
