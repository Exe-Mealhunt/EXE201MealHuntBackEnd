using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class RecipeModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public string? Video { get; set; }

    public int? Status { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual List<RecipeIngredientModel> RecipeIngredients { get; set; } = new List<RecipeIngredientModel>();

    public virtual List<RecipeTagModel> RecipeTags { get; set; } = new List<RecipeTagModel>();

    public virtual List<SavedRecipeModel> SavedRecipes { get; set; } = new List<SavedRecipeModel>();

    public virtual List<ShoppingListModel> ShoppingLists { get; set; } = new List<ShoppingListModel>();
}
