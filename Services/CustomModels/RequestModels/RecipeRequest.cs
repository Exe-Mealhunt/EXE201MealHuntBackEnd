using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class RecipeRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public int UserId { get; set; }
		
		[Required]		
		public string Video { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public string Tutorial { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		[Required]
		public int OccasionId { get; set; }

		[Required]
		public List<RecipeIngredientRequest> Ingredients { get; set; }
	}
}
