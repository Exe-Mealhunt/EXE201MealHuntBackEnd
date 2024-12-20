﻿using MealHunt_Services.CustomModels.ResponseModels;
using System;
using System.Collections.Generic;

namespace MealHunt_Services.BusinessModels;

public partial class PostModel
{
    public int Id { get; set; }

	public PostUserResponse? Author { get; set; }

	public string? Title { get; set; }

    public string? Content { get; set; }

    public string? ImgUrl { get; set; }

    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual List<CommentModel> Comments { get; set; }
}
