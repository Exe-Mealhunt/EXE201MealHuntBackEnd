using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
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
		private readonly IMapper _mapper;

		public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IMapper mapper)
		{
			_recipeIngredientRepository = recipeIngredientRepository;
			_mapper = mapper;
		}

		public async Task AddAllAsync(Recipe addedRecipe, List<RecipeIngredientRequest> recipeIngredients)
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task AddAsync(RecipeIngredientModel recipeIngredientModel)
		{
			try
			{
				var recipeIngredient = _mapper.Map<RecipeIngredient>(recipeIngredientModel);
				await _recipeIngredientRepository.AddAsync(recipeIngredient);
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
				await _recipeIngredientRepository.DeleteAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<RecipeIngredientModel>> GetByRecipeId(int id)
		{
			try
			{
				var recipeIngredients = await _recipeIngredientRepository.GetByRecipeId(id);
				return _mapper.Map<List<RecipeIngredientModel>>(recipeIngredients);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task UpdateAsync(RecipeIngredientModel recipeIngredientModel)
		{
			try
			{
				var recipeIngredient = _mapper.Map<RecipeIngredient>(recipeIngredientModel);
				await _recipeIngredientRepository.UpdateAsync(recipeIngredient);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
