using Microsoft.AspNetCore.Mvc;
using OffersManagement.Domain.Contracts;

namespace OffersManagement.Host.WebApi.Controllers
{
    [ApiController]
    [Route("api/offer")]
    public class OfferController
        : ControllerBase
    {

        private readonly IOfferService _offerService;
        private readonly IOfferConverter _offerConverter;

        public OfferController(IOfferService offerService,
                               IOfferConverter offerConverter)
        {
            _offerService = offerService;
            _offerConverter = offerConverter;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var offers = await _offerService.GetAllAsync();          
            var offersModel = _offerConverter.Convert(offers);

            return Ok(offersModel);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateAsync(OfferModel model)
        {          
            var offer = _offerConverter.Convert(model);
            var result = await _offerService.CreateAsync(offer);

            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync(OfferModel model)
        {        
            var offer = _offerConverter.Convert(model);
            var result = await _offerService.UpdateAsync(offer);

            return Ok(result);
        }

    }
}