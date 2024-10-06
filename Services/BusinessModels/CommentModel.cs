using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class CommentModel
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ReplyToId { get; set; }

    public int? PostId { get; set; }

    public string? Content { get; set; }

    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual PostModel? Post { get; set; }

    public virtual UserModel? User { get; set; }
}
