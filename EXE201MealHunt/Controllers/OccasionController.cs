using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/occasions")]
    public class OccasionController : ControllerBase
    {
        private readonly ILogger<OccasionController> _logger;
        private readonly IOccasionService _occasionService;

        public OccasionController(ILogger<OccasionController> logger, IOccasionService occasionService)
        {
            _logger = logger;
            _occasionService = occasionService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOccasions()
        {
            try
            {
                var response = await _occasionService.GetAllOccasions();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
