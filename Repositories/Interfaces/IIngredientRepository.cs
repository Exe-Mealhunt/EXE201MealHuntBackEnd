using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetIngredientsAsync(string searchValue);

        Task<List<Ingredient>> GetIngredientsOfRecipe(int recipeId);

        Task<Ingredient> AddIngredient(Ingredient ingredient);
    }
}
