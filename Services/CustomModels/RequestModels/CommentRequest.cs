using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
	public class CommentRequest
	{
		[Required]
		public int UserId { get; set; }

		[Required]
		public int PostId { get; set; }

		public int? ReplyToId { get; set; } = null;

		[Required]
		public string Content { get; set; }
	}
}
