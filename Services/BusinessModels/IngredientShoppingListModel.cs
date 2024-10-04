using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class IngredientShoppingListModel
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }

    public int? ShoppingListId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual IngredientModel? Ingredient { get; set; }

    public virtual ShoppingListModel? ShoppingList { get; set; }
}
