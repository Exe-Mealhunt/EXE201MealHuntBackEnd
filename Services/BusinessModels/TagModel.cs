using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class TagModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual List<RecipeTagModel> RecipeTags { get; set; } = new List<RecipeTagModel>();
}
