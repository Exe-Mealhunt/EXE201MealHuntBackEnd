using MealHunt_APIs.ViewModels.ResponseModel;
using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Implements;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
    [Route("api/ingredientShoppingList")]
    [ApiController]
    public class IngredientShoppingListController : ControllerBase
    {
        private readonly IIngredientShoppingListService _ingredientShoppingListService;
        private readonly IShoppingListService _shoppingListService;

        public IngredientShoppingListController(IIngredientShoppingListService ingredientShoppingListService, IShoppingListService shoppingListService)
        {
            _ingredientShoppingListService = ingredientShoppingListService;
            _shoppingListService = shoppingListService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientShoppingList(int ingredientId, int recipeId, int userId)
        {
            if (ingredientId == null || recipeId == null || userId == null) return BadRequest("Enter userId please");
            try
            {

                var response = await _ingredientShoppingListService.AddIngredientShoppingList(ingredientId, recipeId, userId);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
