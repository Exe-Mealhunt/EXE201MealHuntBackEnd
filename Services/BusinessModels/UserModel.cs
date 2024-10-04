using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class UserModel
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual List<CommentModel> Comments { get; set; } = new List<CommentModel>();

    public virtual List<PostModel> Posts { get; set; } = new List<PostModel>();

    public virtual List<SavedRecipeModel> SavedRecipes { get; set; } = new List<SavedRecipeModel>();

    public virtual List<ShoppingListModel> ShoppingLists { get; set; } = new List<ShoppingListModel>();
}
