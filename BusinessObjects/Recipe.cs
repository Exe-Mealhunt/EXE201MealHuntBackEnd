using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Recipe
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public string? Video { get; set; }

    public int? Status { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();

    public virtual ICollection<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
