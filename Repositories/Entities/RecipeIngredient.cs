using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class RecipeIngredient
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? RecipeId { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
