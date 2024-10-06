using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeModel> GetRecipeDetails(int id);

        Task<PagedList<RecipeModel>> GetRecipes(RecipeParameters parameters);
    }
}
