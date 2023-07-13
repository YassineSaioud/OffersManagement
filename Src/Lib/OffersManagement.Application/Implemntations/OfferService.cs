using OffersManagement.Domain.Contracts;
using OffersManagement.Domain.Entities;

namespace OffersManagement.Application
{
    public class OfferService
        : IOfferService
    {

        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            var offers = await _offerRepository.GetAllAsync();
            if (offers is null)
            {
                throw new Exception("Empty result.");
            }

            return offers;
        }

        public async Task<int> CreateAsync(Offer offer)
        {
            if (offer is null)
            {
                throw new ArgumentNullException(nameof(offer), "Can not create a empty offer.");
            }

            return await _offerRepository.AddAsync(offer);
        }

        public async Task<int> UpdateAsync(Offer offer)
        {
            if (offer is null)
            {
                throw new ArgumentNullException(nameof(offer), "Can not update a empty offer.");
            }

            return await _offerRepository.UpdateAsync(offer);
        }

    }
}

