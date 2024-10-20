using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class UserRequest
	{
		public string? FullName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

	}
}
