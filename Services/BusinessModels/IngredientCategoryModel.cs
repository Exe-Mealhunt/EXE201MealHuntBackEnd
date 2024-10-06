using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MealHunt_Services.BusinessModels
{
    public partial class IngredientCategoryModel
    {
        public int Id { get; set; }

        public int? IngredientId { get; set; }

        public int? CategoryId { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? Status { get; set; }

        [JsonIgnore]
        public virtual CategoryModel? Category { get; set; }

        public virtual IngredientModel? Ingredient { get; set; }
    }
}
