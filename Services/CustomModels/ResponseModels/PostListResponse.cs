using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
	public class PostListResponse
	{
		public int Id { get; set; }

		public string? CreatedBy { get; set; }

		public string? Title { get; set; }

		public double? Rating { get; set; }

		public DateTime CreatedAt { get; set; }

		public int? Status { get; set; }

		// public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

		// public virtual User? User { get; set; }
	}
}
