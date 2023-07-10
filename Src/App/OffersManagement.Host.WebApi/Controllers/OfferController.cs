using Microsoft.AspNetCore.Mvc;

namespace OffersManagement.Host.WebApi.Controllers
{
    [ApiController]
    [Route("api/offer")]
    public class OfferController
        : ControllerBase
    {

        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var offersModel = await _offerService.GetAllAsync();
            return Ok(offersModel);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateAsync(OfferModel model)
        {
            var result = await _offerService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync(OfferModel model)
        {
            var result = await _offerService.UpdateAsync(model);
            return Ok(result);
        }

    }
}