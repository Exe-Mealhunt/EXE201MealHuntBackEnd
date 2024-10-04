using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class IngredientShoppingList
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? ShoppingListsId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual ShoppingList? ShoppingLists { get; set; }
}
