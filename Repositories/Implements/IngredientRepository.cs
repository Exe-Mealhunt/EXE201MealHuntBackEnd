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
    }
}
