using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDetailsResponse> GetRecipeDetails(int id);

        Task<PagedList<RecipeListResponse>> GetRecipes(RecipeParameters parameters);

        Task<List<Ingredient4RecipeDetails>> GetMissingIngredientsOfRecipe(int id, string[] ingredientNames);

        Task AddRecipe(RecipeRequest recipeModel);
    }
}
