using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class ShoppingList
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? UserId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<IngredientShoppingListss> IngredientShoppingListsses { get; set; } = new List<IngredientShoppingListss>();

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
