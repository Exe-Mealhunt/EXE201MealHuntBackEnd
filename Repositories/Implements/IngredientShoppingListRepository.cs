using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class IngredientShoppingListRepository : IIngredientShoppingListRepository
    {
        private readonly MealHuntContext _context;

        public IngredientShoppingListRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<IngredientShoppingList> AddIngredientShoppingList(IngredientShoppingList ingredientShoppingList)
        {
            try
            {
                await _context.IngredientShoppingLists.AddAsync(ingredientShoppingList);
                await _context.SaveChangesAsync();
                return ingredientShoppingList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
