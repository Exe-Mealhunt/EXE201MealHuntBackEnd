using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
	public interface ICommentService
	{
		Task PostComment(CommentRequest commentRequest);

		Task EditComment(CommentRequest commentRequest);

		Task DeleteComment(int id);

		Task<ICollection<CommentModel>> GetPostComments(int postId);

		Task<ICollection<CommentModel>> GetUserComments(int userId);

		Task<ICollection<CommentModel>> GetRepliedComments(int commentId);
	}
}
