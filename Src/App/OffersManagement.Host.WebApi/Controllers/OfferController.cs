using Microsoft.AspNetCore.Mvc;

namespace OffersManagement.Host.WebApi.Controllers
{
    [ApiController]
    [Route("api/offer")]
    public class OfferController
        : ControllerBase
    {

        private readonly IOfferAdapter _offerAdapter;

        public OfferController(IOfferAdapter offerAdapter)
        {

            _offerAdapter = offerAdapter;
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<OfferModel>> GetAllOffers()
        {
            var offersModel = _offerAdapter.GetOffers();
            return Ok(offersModel);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddOffer(OfferModel model)
        {
            _offerAdapter.AddOffer(model);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateOffer(OfferModel model)
        {
            _offerAdapter.UpdateOffer(model);
            return Ok();
        }

    }
}