using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class ShoppingList
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<IngredientShoppingList> IngredientShoppingLists { get; set; } = new List<IngredientShoppingList>();

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
