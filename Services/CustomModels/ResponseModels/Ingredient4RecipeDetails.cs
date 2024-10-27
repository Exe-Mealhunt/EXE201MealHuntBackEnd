using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
    public class Ingredient4RecipeDetails
    {
        public int Id { get; set; }

        public string? IngredientName { get; set; }

        public string? Unit { get; set; }

        public double? Quantity { get; set; }

        public bool? IsInShoppingList { get; set; }

        public List<string>? CategoryNames { get; set; }
    }
}
