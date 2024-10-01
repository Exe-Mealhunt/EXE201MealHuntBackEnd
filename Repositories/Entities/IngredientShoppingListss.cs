using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class IngredientShoppingListss
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? ShoppingListsId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual ShoppingList? ShoppingLists { get; set; }
}
