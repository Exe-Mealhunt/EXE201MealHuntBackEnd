using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MealHunt_Services.BusinessModels;

public partial class IngredientModel
{
    public int Id { get; set; }

    public string? IngredientName { get; set; }

    //public string? Type { get; set; }

    //public string? Unit { get; set; }

    //public double? Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual List<IngredientShoppingListModel> IngredientShoppingLists { get; set; } = new List<IngredientShoppingListModel>();

    [JsonIgnore]
    public virtual List<RecipeIngredientModel> RecipeIngredients { get; set; } = new List<RecipeIngredientModel>();

    [JsonIgnore]
    public virtual List<IngredientCategoryModel> IngredientCategories { get; set; } = new List<IngredientCategoryModel>();
}
