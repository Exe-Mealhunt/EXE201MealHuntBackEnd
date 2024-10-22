using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
	public class PostUserResponse
	{
		public int Id { get; set; }
		public string UserName { get; set; } = string.Empty;
		public string UserEmail { get; set; }
		public string Role { get; set; }
	}
}
