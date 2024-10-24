using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly ILogger<MediaController> _logger;
        private readonly ICloudinaryService _cloudinaryService;

        public MediaController(ILogger<MediaController> logger, ICloudinaryService cloudinaryService)
        {
            _logger = logger;
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _cloudinaryService.UploadImageAsync(file);
            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok(new { url = result.SecureUrl, publicId = result.PublicId });
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> DeleteImage(string publicId)
        {
            var result = await _cloudinaryService.DeleteImageAsync(publicId);
            if (result.Result == "ok")
            {
                return Ok(new { message = "Image deleted successfully" });
            }

            return BadRequest(new { message = "Failed to delete image" });
        }
    }
}
