﻿using MealHunt_Repositories.Entities;
using MealHunt_Services.CustomModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
	public interface IRecipeIngredientService
	{
		Task<RecipeIngredient> AddAsync(RecipeIngredient recipeIngredient);
		Task UpdateAsync(RecipeIngredient recipeIngredient);
		Task DeleteAsync(int id);
		Task AddAllAsync(Recipe addedRecipe, List<RecipeIngredientRequest> recipeIngredients);
	}
}