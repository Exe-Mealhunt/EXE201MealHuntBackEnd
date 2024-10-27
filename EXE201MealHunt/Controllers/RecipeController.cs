using MealHunt_APIs.ViewModels.ResponseModel;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
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
        public async Task<IActionResult> GetRecipeDetails(int id, int userId, [FromQuery] string[] ingredientNames = null)
        {
            if (id <= 0)
                return BadRequest("Invalid Id!");
            try
            {
                var recipeResponse = await _recipeService.GetRecipeDetails(id);
                var missingIngredients = await _recipeService.GetMissingIngredientsOfRecipe(id, userId, ingredientNames);
                var response = new RecipeDetailsPageResponse
                {
                    Recipe = recipeResponse,
                    MissingIngredients = missingIngredients
                };
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
                var recipes = await _recipeService.GetRecipes(parameters);

                // Header
                //var metadata = new
                //{
                //    totalCount = response.TotalCount,
                //    pageSize = response.PageSize,
                //    currentPage = response.CurrentPage,
                //    totalPages = response.TotalPages,
                //    hasNext = response.HasNext,
                //    hasPrevious = response.HasPrevious
                //};
                //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

                // Body
                var response = new RecipePagingResponse
                {
                    Recipes = recipes,
                    TotalPages = recipes.TotalPages,
                    CurrentPage = recipes.CurrentPage,
                    PageSize = recipes.PageSize,
                    TotalCount = recipes.TotalCount,
                    HasPrevious = recipes.HasPrevious,
                    HasNext = recipes.HasNext
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] RecipeRequest recipeRequest)
        {
			if (recipeRequest == null)
			{
				return BadRequest("Recipe data is null.");
			}

			if (string.IsNullOrEmpty(recipeRequest.Name))
			{
				return BadRequest("Recipe name is required.");
			}

			await _recipeService.AddRecipe(recipeRequest);
			return Ok(recipeRequest);
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (id <= 0) return BadRequest("Invalid id");

            await _recipeService.DeleteRecipe(id);
            return Ok();
        }
    }
}
