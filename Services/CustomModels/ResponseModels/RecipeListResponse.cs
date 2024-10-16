using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
    public class RecipeListResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        //public int? UserId { get; set; }

        //public string? Video { get; set; }

        //public string? Content { get; set; }

        //public string? Tutorial { get; set; }

        public string? ImageUrl { get; set; }

        public int? CookingTime { get; set; }

        public int? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        //public int? OccasionId { get; set; }

        public string? OccasionName { get; set; }

        //public virtual OccasionModel? Occasion { get; set; }

        //public virtual List<RecipeIngredientModel> RecipeIngredients { get; set; } = new List<RecipeIngredientModel>();

        //public virtual List<RecipeTagModel> RecipeTags { get; set; } = new List<RecipeTagModel>();

        //public virtual List<SavedRecipeModel> SavedRecipes { get; set; } = new List<SavedRecipeModel>();

        //public virtual List<ShoppingListModel> ShoppingLists { get; set; } = new List<ShoppingListModel>();
    }
}
