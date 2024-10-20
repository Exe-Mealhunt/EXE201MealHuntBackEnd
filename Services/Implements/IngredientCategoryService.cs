using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
	public class IngredientCategoryService : IIngredientCategoryService
	{
		private readonly IIngredientCategoryRepository _ingredientCategoryRepository;
		
		public IngredientCategoryService(IIngredientCategoryRepository ingredientCategoryRepository)
		{
			_ingredientCategoryRepository = ingredientCategoryRepository;
		}

		public Task AddAllAsync(ICollection<IngredientCategoryModel> ingredientCategories)
		{
			throw new NotImplementedException();
		}

		public async Task AddAllByIdAsync(Ingredient ingredient, ICollection<int> ingredientCategoryIds)
		{
			List<IngredientCategory> ingredientCategories = new();

			foreach (var item in ingredientCategoryIds)
			{
				IngredientCategory ingredientCategory = new IngredientCategory()
				{
					IngredientId = ingredient.Id,
					CategoryId = item,
					CreatedAt = DateTime.UtcNow,
				};

				ingredientCategories.Add(ingredientCategory);
			}

			await _ingredientCategoryRepository.AddAllAsync(ingredientCategories);
		}

		public Task<IngredientCategoryModel> AddAsync(IngredientCategoryModel ingredientCategoryModel)
		{
			throw new NotImplementedException();
		}
	}
}
