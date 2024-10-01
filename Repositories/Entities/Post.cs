using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Post
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public double? Rating { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? User { get; set; }
}
