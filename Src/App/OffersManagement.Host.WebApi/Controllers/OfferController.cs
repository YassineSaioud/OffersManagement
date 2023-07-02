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
        public ActionResult<IEnumerable<OfferModel>> GetAll()
        {
            var offersModel = _offerService.GetAll();
            return Ok(offersModel);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(OfferModel model)
        {
            _offerService.Create(model);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(OfferModel model)
        {
            _offerService.Update(model);
            return Ok();
        }

    }
}