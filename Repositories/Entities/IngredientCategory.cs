using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class IngredientCategory
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? CategoryId { get; set; }

    public string? Name { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Ingredient? Ingredient { get; set; }
}
