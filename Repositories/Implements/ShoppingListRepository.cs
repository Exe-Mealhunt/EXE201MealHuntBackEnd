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
    }
}
