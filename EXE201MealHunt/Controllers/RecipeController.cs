using MealHunt_Repositories.Parameters;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeDetails(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id!");
            try
            {
                var response = await _recipeService.GetRecipeDetails(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromQuery] RecipeParameters parameters)
        {
            try
            {
                var response = await _recipeService.GetRecipes(parameters);
                var metadata = new
                {
                    totalCount = response.TotalCount,
                    pageSize = response.PageSize,
                    currentPage = response.CurrentPage,
                    totalPages = response.TotalPages,
                    hasNext = response.HasNext,
                    hasPrevious = response.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }
    }
}
