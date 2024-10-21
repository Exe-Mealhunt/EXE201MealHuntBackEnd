using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public int? Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();

    public virtual ICollection<UserSubscription>? UserSubscriptions { get; set; } = new List<UserSubscription>();

    public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();  
}
