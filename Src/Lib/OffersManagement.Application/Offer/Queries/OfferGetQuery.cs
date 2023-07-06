using OffersManagement.Domain.Contracts;

namespace OffersManagement.Application.Offer
{
    public class OfferGetQuery
        : IOfferGetQuery

    {
        private readonly IProductRepository _productRepository;

        public OfferGetQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Domain.Entities.Offer> Handle()
        {
            var products = _productRepository.GetAll();
            return from product in products
                   select new Domain.Entities.Offer(product);
        }
    }
}
