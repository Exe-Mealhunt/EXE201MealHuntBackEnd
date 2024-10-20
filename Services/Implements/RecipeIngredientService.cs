using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
	public class RecipeIngredientService : IRecipeIngredientService
	{
		private readonly IRecipeIngredientRepository _recipeIngredientRepository;

		public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
		{
			_recipeIngredientRepository = recipeIngredientRepository;
		}

		public async Task AddAllAsync(Recipe addedRecipe, List<RecipeIngredientRequest> recipeIngredients)
		{
			List<RecipeIngredient> ingredients = new List<RecipeIngredient>();

            foreach (var item in recipeIngredients)
            {
				RecipeIngredient rc = new()
				{
					RecipeId = addedRecipe.Id,
					IngredientId = item.IngredientId,
					Quantity = item.Quantity,
					Unit = item.Unit,
					CreatedAt = DateTime.UtcNow,
				};

				Console.WriteLine($"{rc.RecipeId}, {rc.IngredientId}, {rc.Quantity}, {rc.Unit}");

				ingredients.Add(rc);
            }

			await _recipeIngredientRepository.AddAllAsync(ingredients);
        }

		public async Task<RecipeIngredient> AddAsync(RecipeIngredient recipeIngredient)
		{
			await _recipeIngredientRepository.AddAsync(recipeIngredient);
			return recipeIngredient;
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(RecipeIngredient recipeIngredient)
		{
			throw new NotImplementedException();
		}
	}
}
