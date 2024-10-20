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
	public class IngredientCategoryRepository : IIngredientCategoryRepository
	{
		private readonly MealHuntContext _context;

		public IngredientCategoryRepository(MealHuntContext context )
		{
			_context = context;
		}

		public async Task AddAllAsync(ICollection<IngredientCategory> ingredientCategories)
		{
			try
			{
				await _context.AddRangeAsync(ingredientCategories);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task AddAsync(IngredientCategory ingredientCategory)
		{
			try
			{
				await _context.AddAsync(ingredientCategory);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw;
			}
		}
	}
}
