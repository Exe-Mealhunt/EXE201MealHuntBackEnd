using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList> AddShoppingList(ShoppingList shoppingList);
        Task<List<ShoppingList>> GetShoppingLists(int userId);

    }
}
