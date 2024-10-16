using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly MealHuntContext _context;

        public RecipeRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<Recipe?> GetRecipeById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Invalid Id!");
            return await _context.Recipes
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                    .ThenInclude(i => i.IngredientCategories)
                    .ThenInclude(ic => ic.Category)
                .Include(r => r.Occasion)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<PagedList<Recipe>> GetRecipes(RecipeParameters parameters)
        {
            try
            {
                var recipesQuery = _context.Recipes
                    .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                    .Include(r => r.Occasion)
                    .AsQueryable();

                if (recipesQuery.Any())
                {
                    // Filter 
                    // Ingredient names
                    if (parameters.IngredientNames.Length > 0)
                    {
                        //recipesQuery = recipesQuery
                        //    .Where(r => CheckRecipeHasIngredients(parameters.IngredientNames, r));

                        recipesQuery = recipesQuery
                            .Where(r => parameters.IngredientNames
                                .All(ingredientName => r.RecipeIngredients
                                    .Any(ri => ri.Ingredient.IngredientName.Trim().ToLower().Equals(ingredientName.Trim().ToLower()))));
                    }

                    // Occasion name
                    if (!string.IsNullOrEmpty(parameters.OccasionName)
                        || !string.IsNullOrWhiteSpace(parameters.OccasionName))
                    {
                        recipesQuery = recipesQuery
                            .Where(r => r.Occasion.Name.Trim().ToLower().Equals(parameters.OccasionName.Trim().ToLower()));
                    }

                    // Search
                    SearchByName(ref recipesQuery, parameters.SearchValue);
                }
                
                return await PagedList<Recipe>
                    .ToPagedList(recipesQuery, parameters.PageNumber, parameters.PageSize);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RecipeIngredient>> GetRecipeIngredientsOfRecipe(int id)
        {
            var recipeIngredients = new List<RecipeIngredient>();   
            try
            {
                recipeIngredients = await _context.RecipeIngredients
                    .Include(ri => ri.Ingredient).ThenInclude(i => i.IngredientCategories).ThenInclude(ic => ic.Category)
                    .Where(ri => ri.RecipeId == id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recipeIngredients;
        }

        private bool CheckRecipeHasIngredients(string[] ingredientsName, Recipe recipe)
        {
            for(int i = 0; i < ingredientsName.Length; i++)
            {
                // Check if any ingredients of the recipe has name is equal to the ingredient name [i]
                if(!recipe.RecipeIngredients
                    .Any(ri => ri.Ingredient.IngredientName.Trim().ToLower().Equals(ingredientsName[i].Trim().ToLower())))
                {
                    return false;
                }
            }
            return true;
        }

        private void SearchByName(ref IQueryable<Recipe> recipes, string searchValue)
        {
            if (!recipes.Any() || string.IsNullOrWhiteSpace(searchValue))
                return;
            recipes = recipes.Where(r => r.Name.ToLower().Trim().Contains(searchValue.Trim().ToLower()));
        }
    }
}
