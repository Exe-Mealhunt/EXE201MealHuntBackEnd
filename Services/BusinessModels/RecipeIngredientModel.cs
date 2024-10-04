using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class RecipeIngredientModel
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? RecipeId { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual IngredientModel? Ingredient { get; set; }

    public virtual RecipeModel? Recipe { get; set; }
}
