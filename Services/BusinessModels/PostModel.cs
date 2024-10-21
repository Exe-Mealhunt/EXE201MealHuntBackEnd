using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class PostModel
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual List<CommentModel> Comments { get; set; } = new List<CommentModel>();

    // public virtual UserModel? User { get; set; }
}
