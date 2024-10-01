using System;
using System.Collections.Generic;

namespace MealHunt_Repositories;

public partial class Tip
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }
}
