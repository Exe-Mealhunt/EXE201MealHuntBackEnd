using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class IngredientRequest
	{
		[Required]
		public string IngredientName { get; set; }

		[Required]
		public List<int> CategoryIds { get; set; } = new();
	}
}
