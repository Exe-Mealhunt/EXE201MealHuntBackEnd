using AutoMapper;
using MealHunt_Repositories.Entities;
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
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMapper _mapper;

        public ShoppingListService(IShoppingListRepository shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingListModel> AddShoppingList(ShoppingListModel shoppingListModel)
        {
            try
            {
                var shoppingList = _mapper.Map<ShoppingList>(shoppingListModel);
                var response = await _shoppingListRepository.AddShoppingList(shoppingList);
                var resposneModel = _mapper.Map<ShoppingListModel>(response);
                return resposneModel;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ShoppingListModel>> GetShoppingLists(int userId)
        {
            try
            {
                var shoppingLists = await _shoppingListRepository.GetShoppingLists(userId);
                var response = _mapper.Map<List<ShoppingListModel>>(shoppingLists);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteShoppingList(int shoppingListId)
        {
            try
            {
                // Check if the shopping list exists
                var shoppingList = await _shoppingListRepository.GetByIdAsync(shoppingListId);
                if (shoppingList == null)
                {
                    throw new KeyNotFoundException($"Shopping list with ID {shoppingListId} not found.");
                }

                // Remove related ShoppingListIngredients
                if (shoppingList.IngredientShoppingLists != null && shoppingList.IngredientShoppingLists.Any())
                {
                    await _shoppingListRepository.RemoveShoppingListIngredients(shoppingListId);
                }

                // Delete the shopping list itself
                var result = await _shoppingListRepository.DeleteShoppingLists(shoppingListId);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the shopping list: {ex.Message}");
            }
        }
    }
}
