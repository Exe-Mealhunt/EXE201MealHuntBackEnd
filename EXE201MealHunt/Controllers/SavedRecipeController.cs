using MealHunt_APIs.ViewModels.ResponseModel;
using MealHunt_Repositories.Entities;
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


        [HttpPost("add-saved-recipe")]
        public async Task<IActionResult> AddSavedRecipe([Required] int recipeId, [Required] int userId)
        {
            if (recipeId == null) return BadRequest("Enter recipe id please");
            if (userId == null) return BadRequest("Enter user id please");
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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSavedRecipe([Required] int userId)
        {
            if (userId == null) return BadRequest("Enter user id please");
            try
            {
                //var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                //int.TryParse(userIdClaim, out int userId);
                var savedRecipe = await _savedRecipeService.GetSavedRecipe(userId);
                var response = savedRecipe.Select(sr => new GetSavedRecipeResponse
                {
                    Id = sr.Id,
                    RecipeId = sr.RecipeId,
                    RecipeName = sr.Recipe.Name,
                    UserId = sr.UserId,
                    CreatedAt = sr.CreatedAt,
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
