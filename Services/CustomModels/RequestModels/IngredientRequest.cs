using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class IngredientRequest
	{
		public string? IngredientName { get; set; }

		public List<IngredientCategoryModel> IngredientCategories { get; set; } = new List<IngredientCategoryModel>();
	}
}
