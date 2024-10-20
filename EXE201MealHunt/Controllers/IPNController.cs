using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("IPN")]
    public class IPNController : ControllerBase
    {
        private readonly ILogger<IPNController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public IPNController(ILogger<IPNController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task PaymentExecute()
        {
            //return Ok("This is IPN api.");
            var request = new RegisterRequest
            {
                FullName = "Momo test 2",
                Email = "momotest2@gmail.com",
                Password = "123456"
            };

            var response = await _authenticationService.Register(request);
            //return Ok(response);
        }
    }
}
