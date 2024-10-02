using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class RecipeTagModel
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? TagId { get; set; }

    public string? Name { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual RecipeModel? Recipe { get; set; }

    public virtual TagModel? Tag { get; set; }
}
