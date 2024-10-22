using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var response = await _categoryService.GetAllCategories();
                return Ok(response); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message= ex.Message });
            }
        }
    }
}
