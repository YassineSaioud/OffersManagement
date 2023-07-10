namespace OffersManagement.Host.WebApi
{
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController
        : ControllerBase
    {
        public const string AnInternalErrorAsOccurred = "An internal error as occurred";
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError(context.Error.Message,
                                context.Error,
                                new
                                {
                                    Type = "logs",
                                });

            return Problem(title: AnInternalErrorAsOccurred,
                           statusCode: (int)HttpStatusCode.InternalServerError,
                           detail: context.Error.Message);
        }
    }
}