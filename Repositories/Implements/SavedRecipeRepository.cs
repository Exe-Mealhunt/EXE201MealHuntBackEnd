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
    public class SavedRecipeRepository : ISavedRecipeRepository
    {
        private readonly MealHuntContext _context;

        public SavedRecipeRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<SavedRecipe> AddSavedRecipe(SavedRecipe savedRecipe)
        {
            await _context.SavedRecipes.AddAsync(savedRecipe);
            await _context.SaveChangesAsync();
            return savedRecipe;
        }

        public async Task<List<SavedRecipe>> GetSavedRecipe(int userId)
        {
            try
            {
                List<SavedRecipe> savedRecipe = await _context.SavedRecipes
                    .Where(sr => sr.UserId == userId)
                    .Include(u => u.User)
                    .Include(sr => sr.Recipe)
                    .ToListAsync();
                return savedRecipe;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }
    }
}
