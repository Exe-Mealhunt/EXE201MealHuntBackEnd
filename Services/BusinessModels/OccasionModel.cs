﻿using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.BusinessModels
{
    public partial class OccasionModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? Status { get; set; }

        public virtual List<RecipeModel> Recipes { get; set; } = new List<RecipeModel>();
    }
}