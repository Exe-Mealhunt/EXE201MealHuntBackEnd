﻿using MealHunt_Repositories.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.BusinessModels
{
    public partial class IngredientCategoryModel
    {
        public int Id { get; set; }

        public int? IngredientId { get; set; }

        public int? CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? Status { get; set; }

        [JsonIgnore]
        public virtual CategoryModel? Category { get; set; }

        public virtual IngredientModel? Ingredient { get; set; }
    }
}
