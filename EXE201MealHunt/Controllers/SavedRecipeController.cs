using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MealHunt_APIs.Controllers
{
    [Route("api/saved-recipe")]
    [ApiController]
    public class SavedRecipeController : ControllerBase
    {
        private readonly ISavedRecipeService _savedRecipeService;
        public SavedRecipeController(ISavedRecipeService savedRecipeService)
        {
            _savedRecipeService = savedRecipeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddSavedRecipe([Required] int recipeId, [Required] int userId)
        {
            if (recipeId == null) return BadRequest("Enter recipe id please");
            try
            {
                //var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                //int.TryParse(userIdClaim, out int userId);
                var savedRecipe = await _savedRecipeService.AddSavedRecipe(recipeId, userId);
                return Ok(savedRecipe);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
