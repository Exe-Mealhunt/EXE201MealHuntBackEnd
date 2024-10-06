using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Parameters
{
    public class RecipeParameters : QueryStringParameters
    {
        [FromQuery(Name = "search-value")]
        public string? SearchValue { get; set; }

        [FromQuery(Name = "occasion-name")]
        public string? OccasionName { get; set; }

        [FromQuery(Name = "ingredient-names")]
        public string[]? IngredientNames { get; set; } = [];
    }
}
