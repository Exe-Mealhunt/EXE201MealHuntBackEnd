using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class IngredientModel
{
    public int Id { get; set; }

    public string? IngredientName { get; set; }

    public string? Type { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual List<IngredientShoppingListModel> IngredientShoppingLists { get; set; } = new List<IngredientShoppingListModel>();

    public virtual List<RecipeIngredientModel> RecipeIngredients { get; set; } = new List<RecipeIngredientModel>();
}
