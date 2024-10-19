using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
	public interface IRecipeIngredientRepository
	{
		Task<RecipeIngredient> GetById(int id);
		Task<RecipeIngredient> AddAsync(RecipeIngredient recipeIngredient);
		Task UpdateAsync(RecipeIngredient recipeIngredient);
		Task DeleteAsync(int id);
		Task AddAllAsync(List<RecipeIngredient> ingredients);
	}
}
