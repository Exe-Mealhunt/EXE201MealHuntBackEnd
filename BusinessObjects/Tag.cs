using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
}
