using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<IngredientCategory> IngredientCategories { get; set; } = new List<IngredientCategory>();
}
