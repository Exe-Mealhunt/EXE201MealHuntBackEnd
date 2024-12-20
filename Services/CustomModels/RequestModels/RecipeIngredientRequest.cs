﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class RecipeIngredientRequest
	{
		[Required]
		public int IngredientId { get; set; }

		
		public string? Unit { get; set; }

		
		public double? Quantity { get; set; }
	}
}
