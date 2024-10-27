using MealHunt_APIs.ViewModels.ResponseModel;
using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [Route("api/shopping-lists")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpPost("add-shopping-list")]
        public async Task<IActionResult> AddShoppingList(int userId, int recipeId)
        {
            if (userId == null || recipeId == null) return BadRequest("Enter userId, recipeId please");
            try
            {
                var response = await _shoppingListService.AddShoppingList(new ShoppingListModel
                {
                    RecipeId = recipeId,
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                });
                return Ok(response);

            }catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [HttpGet("get-shopping-lists")]
        public async Task<IActionResult> GetShoppingLists(int userId)
        {
            if (userId == null) return BadRequest("Enter userId please");
            try
            {
                var shoppingLists =  await _shoppingListService.GetShoppingLists(userId);
                var response = shoppingLists.Select(sl => new ShoppingListsUserProfileResponse
                {
                    Name = sl.Recipe.Name,
                    ImgUrl = sl.Recipe.ImageUrl,
                    IngredientUnits = sl.IngredientShoppingLists.Select(isl => new IngredientUnitQuantityShoppingListResponse
                    {
                        IngredientName = isl.Ingredient?.IngredientName,
                        Quantity = isl.Ingredient?.RecipeIngredients.FirstOrDefault()?.Quantity,
                        Unit = isl.Ingredient?.RecipeIngredients.FirstOrDefault()?.Unit
                    }).ToList(),
                });
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
