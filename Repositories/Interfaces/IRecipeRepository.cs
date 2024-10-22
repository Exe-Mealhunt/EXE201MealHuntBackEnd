using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;

namespace MealHunt_Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe?> GetRecipeById(int id);

        Task<PagedList<Recipe>> GetRecipes(RecipeParameters parameters);

        Task<List<RecipeIngredient>> GetRecipeIngredientsOfRecipe(int id);

        Task<Recipe> AddRecipe(Recipe recipe); 

        Task<Recipe> DeleteRecipe(int id);

        Task<Recipe> UpdateRecipe(Recipe recipe);
    }
}
