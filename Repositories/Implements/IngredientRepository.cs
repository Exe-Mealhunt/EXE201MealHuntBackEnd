using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MealHuntContext _context;

        public IngredientRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<List<Ingredient>> GetIngredientsAsync(string searchValue)
        {
            try
            {
                if (searchValue == null) searchValue = "";
                var ingredients = await _context.Ingredients.Where(i => i.IngredientName.Contains(searchValue)).ToListAsync();
                return ingredients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ingredient>> GetIngredientsOfRecipe(int recipeId)
        {
            var ingredients = new List<Ingredient>();
            try
            {
                ingredients = await _context.Ingredients.Include(i => i.RecipeIngredients)
                    .Where(i => i.RecipeIngredients
                        .Any(ri => ri.RecipeId == recipeId))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ingredients;
        }
    }
}
