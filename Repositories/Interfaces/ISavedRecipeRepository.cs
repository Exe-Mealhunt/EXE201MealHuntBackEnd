using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface ISavedRecipeRepository
    {
        Task<SavedRecipe> AddSavedRecipe(SavedRecipe savedRecipe);
        Task<List<SavedRecipe>> GetSavedRecipe(int userId);
    }
}
