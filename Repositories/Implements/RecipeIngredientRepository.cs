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

		public async Task DeleteAsync(int id)
		{
			try
			{
				var recipeIngredient = await _context.RecipeIngredients.FindAsync(id) ?? throw new Exception("Recipe Ingredient does not exist");
				_context.RecipeIngredients.Remove(recipeIngredient);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<RecipeIngredient> GetById(int id)
		{
			try
			{
				return await _context.RecipeIngredients.FindAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<RecipeIngredient>> GetByRecipeId(int id)
		{
			try
			{
				return await _context.RecipeIngredients.Where(ri => ri.RecipeId == id).ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task UpdateAsync(RecipeIngredient recipeIngredient)
		{
			try
			{
				if (await _context.RecipeIngredients.FindAsync(recipeIngredient.Id) == null)
					throw new Exception("Recipe Ingredient does not exist");

				_context.RecipeIngredients.Update(recipeIngredient);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
