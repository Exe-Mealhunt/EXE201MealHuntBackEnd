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

        public IngredientShoppingListService(IIngredientShoppingListRepository ingredientShoppingListRepository, IMapper mapper)
        {
            _ingredientShoppingListRepository = ingredientShoppingListRepository;
            _mapper = mapper;
        }

        public async Task<IngredientShoppingListModel> AddIngredientShoppingList(IngredientShoppingListModel ingredientShoppingListModel)
        {
            try
            {
                var shoppingLists = _mapper.Map<IngredientShoppingList>(ingredientShoppingListModel);
                var shoppingListsResponse = await _ingredientShoppingListRepository.AddIngredientShoppingList(shoppingLists);
                var response = _mapper.Map<IngredientShoppingListModel>(shoppingListsResponse);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
