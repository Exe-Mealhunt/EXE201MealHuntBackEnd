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

        public IngredientShoppingListController(IIngredientShoppingListService ingredientShoppingListService)
        {
            _ingredientShoppingListService = ingredientShoppingListService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientShoppingList(int ingredientId, int shoppingListId)
        {
            if (ingredientId == null || shoppingListId == null) return BadRequest("Enter userId please");
            try
            {

                var ingredientShoppingListModel = _ingredientShoppingListService.AddIngredientShoppingList(new IngredientShoppingListModel
                {
                    IngredientId = ingredientId,
                    ShoppingListsId = shoppingListId,
                    CreatedAt = DateTime.UtcNow
                });
                var response = new IngredientShoppingListResponse
                {
                    IngredientId = ingredientShoppingListModel.Result.IngredientId,
                    ShoppingListsId = ingredientShoppingListModel.Result.ShoppingListsId,
                    CreatedAt = ingredientShoppingListModel.Result.CreatedAt
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
