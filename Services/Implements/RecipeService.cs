using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IIngredientRepository ingredientRepository, IRecipeIngredientService recipeIngredientService)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
            _recipeIngredientService = recipeIngredientService;
        }

        public async Task<RecipeDetailsResponse> GetRecipeDetails(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException("Invalid Id!");
            try
            {
                var recipe = await _recipeRepository.GetRecipeById(id);
                if (recipe == null)
                    throw new Exception($"Recipe with id {id} not found! (RecipeService/GetRecipeDetails)");
                var response = _mapper.Map<RecipeDetailsResponse>(recipe);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<RecipeListResponse>> GetRecipes(RecipeParameters parameters)
        {
            try
            {
                var recipes = await _recipeRepository.GetRecipes(parameters);
                var recipeModels = _mapper.Map<PagedList<RecipeListResponse>>(recipes);
                return new PagedList<RecipeListResponse>(recipeModels, recipes.TotalCount, recipes.CurrentPage, recipes.PageSize);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Ingredient4RecipeDetails>> GetMissingIngredientsOfRecipe(int id, string[] ingredientNames)
        {
            try
            {
                var missingIngredients = await _recipeRepository
                                                    .GetRecipeIngredientsOfRecipe(id);
                var response = _mapper.Map<List<Ingredient4RecipeDetails>>(missingIngredients);
                
                if(ingredientNames != null && ingredientNames.Length > 0)
                {
                    // Check for missing ingredients
                    response = response
                        .Where(i => !ingredientNames.Contains(i.IngredientName))
                        .ToList();
                }
                
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddRecipe(RecipeRequest recipeModel)
        {
            try
            {
                Recipe recipe = new()
                {
                    Name = recipeModel.Name,
                    Tutorial = recipeModel.Tutorial,
                    Content = recipeModel.Content,
                    OccasionId = recipeModel.OccasionId,
                    Video = recipeModel.Video,
					ImageUrl = recipeModel.ImageUrl,
                    UserId = recipeModel.UserId,
					CreatedAt = DateTime.UtcNow,
                };

                var addedRecipe = await _recipeRepository.AddRecipe(recipe);

				await _recipeIngredientService.AddAllAsync(addedRecipe, recipeModel.Ingredients);
			}
			catch
			{
				throw;
			}
		}
    }
}
