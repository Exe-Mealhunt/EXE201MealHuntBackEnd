using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class TipModel
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public int? Status { get; set; }
}
