using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe?> GetRecipeById(int id);

        Task<PagedList<Recipe>> GetRecipes(RecipeParameters parameters);

        Task<List<RecipeIngredient>> GetRecipeIngredientsOfRecipe(int id);

        Task<Recipe> AddRecipe(Recipe recipe); 
    }
}
