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
	public class RecipeIngredientRepository : IRecipeIngredientRepository
	{
		private readonly MealHuntContext _context;

		public RecipeIngredientRepository(MealHuntContext context)
		{
			_context = context;
		}

		public async Task AddAllAsync(List<RecipeIngredient> ingredients)
		{
			try
			{
				await _context.RecipeIngredients.AddRangeAsync(ingredients);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<RecipeIngredient> AddAsync(RecipeIngredient recipeIngredient)
		{
			try
			{
				_context.Entry(recipeIngredient).State = EntityState.Added;
				await _context.SaveChangesAsync();
				return recipeIngredient;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<RecipeIngredient> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(RecipeIngredient recipeIngredient)
		{
			throw new NotImplementedException();
		}
	}
}
