using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Ingredient
{
    public int Id { get; set; }

    public string? IngredientName { get; set; }

    public string? Type { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<IngredientShoppingListss> IngredientShoppingListsses { get; set; } = new List<IngredientShoppingListss>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
