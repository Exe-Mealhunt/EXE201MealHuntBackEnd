using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Implements;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class IngredientShoppingListService : IIngredientShoppingListService
    {
        private readonly IIngredientShoppingListRepository _ingredientShoppingListRepository;
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepository;

        public IngredientShoppingListService(IIngredientShoppingListRepository ingredientShoppingListRepository, IMapper mapper, IShoppingListRepository shoppingListRepository)
        {
            _ingredientShoppingListRepository = ingredientShoppingListRepository;
            _mapper = mapper;
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<IngredientShoppingListModel> AddIngredientShoppingList(int ingredientId, int recipeId, int userId)
        {
            var shoppingList = new List<ShoppingList>();
            // Try to find an existing shopping list for the user, recipe, and ingredient
            try
            {
                shoppingList = await _shoppingListRepository.GetShoppingLists(userId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                throw;
            }
            var existingShoppingList = shoppingList.FirstOrDefault(sl =>
                sl.RecipeId == recipeId);

            IngredientShoppingList ingredientShoppingList = null;

            if (existingShoppingList != null)
            {
                // Add the ingredient to the existing shopping list
                ingredientShoppingList = await _ingredientShoppingListRepository.AddIngredientShoppingList(new IngredientShoppingList
                {
                    CreatedAt = DateTime.UtcNow,
                    IngredientId = ingredientId,
                    ShoppingListsId = existingShoppingList.Id
                });
            }
            else
            {
                // Create a new shopping list for the user and recipe
                var newShoppingListModel = new ShoppingList
                {
                    RecipeId = recipeId,
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                };
                var newShoppingListResponse = await _shoppingListRepository.AddShoppingList(newShoppingListModel);

                // Add the ingredient to the newly created shopping list
                ingredientShoppingList = await _ingredientShoppingListRepository.AddIngredientShoppingList(new IngredientShoppingList
                {
                    CreatedAt = DateTime.UtcNow,
                    IngredientId = ingredientId,
                    ShoppingListsId = newShoppingListResponse.Id
                });
            }

            // Map the entity to the response model
            return _mapper.Map<IngredientShoppingListModel>(ingredientShoppingList);
        }
    }
}
