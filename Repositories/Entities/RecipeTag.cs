using System;
using System.Collections.Generic;

namespace MealHunt_Repositories;

public partial class RecipeTag
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? TagsId { get; set; }

    public string? Name { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual Tag? Tags { get; set; }
}
