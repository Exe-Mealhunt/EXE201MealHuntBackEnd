using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("IPN")]
    public class IPNController : ControllerBase
    {
        private readonly ILogger<IPNController> _logger;

        public IPNController(ILogger<IPNController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult PaymentExecute()
        {
            return Ok("This is IPN api.");
        }
    }
}
