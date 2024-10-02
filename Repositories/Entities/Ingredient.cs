﻿using System;
using System.Collections.Generic;

namespace MealHunt_Repositories;

public partial class Ingredient
{
    public int Id { get; set; }

    public string? IngredientName { get; set; }

    public string? Type { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<IngredientShoppingList> IngredientShoppingLists { get; set; } = new List<IngredientShoppingList>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}