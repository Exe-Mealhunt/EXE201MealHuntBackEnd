using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
	public interface ICommentRepository
	{
		Task<Comment> AddAsync(Comment comment);

		Task<Comment> UpdateAsync(Comment comment);

		Task<Comment> DeleteAsync(int id);

		Task<ICollection<Comment>> GetByPostIdAsync(int postId);

		Task<ICollection<Comment>> GetByUserIdAsync(int userId);
		Task<ICollection<Comment>> GetRepliedCommentsAsync(int commentId);
	}
}
