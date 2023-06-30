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
        public ActionResult<IEnumerable<OfferModel>> GetAll()
        {
            var offersModel = _offerAdapter.GetAll();
            return Ok(offersModel);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(OfferModel model)
        {
            _offerAdapter.Create(model);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(OfferModel model)
        {
            _offerAdapter.Update(model);
            return Ok();
        }

    }
}