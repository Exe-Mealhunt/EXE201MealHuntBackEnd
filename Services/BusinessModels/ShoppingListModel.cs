using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class ShoppingListModel
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? UserId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual List<IngredientShoppingListModel> IngredientShoppingLists { get; set; } = new List<IngredientShoppingListModel>();

    public virtual RecipeModel? Recipe { get; set; }

    public virtual UserModel? User { get; set; }
}
