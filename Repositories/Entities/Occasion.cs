using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class Occasion
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
