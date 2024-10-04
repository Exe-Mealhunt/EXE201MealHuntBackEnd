using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ReplyToId { get; set; }

    public int? PostId { get; set; }

    public string? Content { get; set; }

    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
