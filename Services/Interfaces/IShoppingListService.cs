using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IShoppingListService
    {
        Task<ShoppingListModel> AddShoppingList(ShoppingListModel shoppingListModel);
        Task<List<ShoppingListModel>> GetShoppingLists(int userId);
        Task<bool> DeleteShoppingList(int shoppingListId);
    }
}
