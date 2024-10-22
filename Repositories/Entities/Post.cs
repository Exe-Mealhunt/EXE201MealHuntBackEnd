using System;
using System.Collections.Generic;

namespace MealHunt_Repositories.Entities;

public partial class Post
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? ImgUrl { get; set; }

    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? User { get; set; }
}
