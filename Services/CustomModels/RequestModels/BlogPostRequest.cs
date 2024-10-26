using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class BlogPostRequest
	{
		[Required]
		public int UserId {  get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		public string? ImgUrl { get; set; }
	}
}
