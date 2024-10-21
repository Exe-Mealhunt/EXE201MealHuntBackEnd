using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IIngredientShoppingListService
    {
        Task<IngredientShoppingListModel> AddIngredientShoppingList(int ingredientId, int recipeId, int userId);
    }
}
