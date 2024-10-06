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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MealHuntContext _context;

        public CategoryRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = new List<Category>();
            categories = await _context.Categories
                .Include(c => c.IngredientCategories).ThenInclude(ic => ic.Ingredient)
                .ToListAsync();
            return categories;
        }
    }
}
