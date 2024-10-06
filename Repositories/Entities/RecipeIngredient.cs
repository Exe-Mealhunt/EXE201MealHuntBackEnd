using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class RecipeIngredient
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? RecipeId { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
