using AutoMapper;
using MealHunt_Repositories.Interfaces;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
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

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IIngredientRepository ingredientRepository)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
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
                        .Where(i => !ingredientNames.Contains(i.IngredientName.ToLower()))
                        .ToList();
                }
                
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
