using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly MealHuntContext _context;

        public ShoppingListRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<ShoppingList> AddShoppingList(ShoppingList shoppingList)
        {
            try
            {
                await _context.ShoppingLists.AddAsync(shoppingList);
                await _context.SaveChangesAsync();
                return shoppingList;
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ShoppingList>> GetShoppingLists(int userId)
        {
            try
            {
                var shoppingLists = await _context.ShoppingLists
                    .Where(sl => sl.UserId == userId)
                    .Include(isl => isl.IngredientShoppingLists)
                    .ThenInclude(i => i.Ingredient)
                    .ThenInclude(ri => ri.RecipeIngredients)
                    .Include(r => r.Recipe)
                    .Include(u => u.User)
                    .ToListAsync();
                return shoppingLists;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteShoppingLists(int shoppingListId)
        {
            try
            {
                // Find the shopping list by ID
                var shoppingList = await _context.ShoppingLists.FindAsync(shoppingListId);

                if (shoppingList == null)
                {
                    // Return false if the shopping list doesn't exist
                    return false;
                }

                // Remove the shopping list
                _context.ShoppingLists.Remove(shoppingList);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true; // Return true if deletion succeeded

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShoppingList> GetByIdAsync(int shoppingListId)
        {
            try
            {
                return await _context.ShoppingLists
                    .Include(sl => sl.IngredientShoppingLists) // Include related ShoppingListIngredients
                    .ThenInclude(sli => sli.Ingredient)        // Optionally include the Ingredient details
                    .FirstOrDefaultAsync(sl => sl.Id == shoppingListId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the shopping list: {ex.Message}");
            }
        }

        public async Task RemoveShoppingListIngredients(int shoppingListId)
        {
            var ingredients = _context.IngredientShoppingLists
                .Where(sli => sli.ShoppingListsId == shoppingListId);

            if (ingredients.Any())
            {
                _context.IngredientShoppingLists.RemoveRange(ingredients);
                await _context.SaveChangesAsync();
            }
        }
    }
}
