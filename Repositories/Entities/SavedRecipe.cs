using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class SavedRecipe
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public int? Status { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
