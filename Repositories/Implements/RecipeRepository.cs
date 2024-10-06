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
    public class RecipeRepository : IRecipeRepository
    {
        private readonly MealHuntContext _context;

        public RecipeRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<Recipe?> GetRecipeById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Invalid Id!");
            return await _context.Recipes
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
