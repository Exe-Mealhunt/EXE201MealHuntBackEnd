using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
	public class CommentRepository : ICommentRepository
	{
		private MealHuntContext _context;

		public CommentRepository(MealHuntContext context)
		{
			_context = context;
		}

		public async Task<Comment> AddAsync(Comment comment)
		{
			try
			{
				await _context.AddAsync(comment);
				await _context.SaveChangesAsync();
				
				return comment;
			}
			catch
			{
				throw;
			}
		}

		public async Task<Comment> DeleteAsync(int id)
		{
			try
			{
				var comment = await _context.Comments.FindAsync(id) ?? throw new Exception("Comment with ID not found");
				
				_context.Comments.Remove(comment);
				await _context.SaveChangesAsync();
				
				return comment;
			}
			catch
			{
				throw;
			}
		}

		public async Task<ICollection<Comment>> GetByPostIdAsync(int postId)
		{
			try
			{
				if (await _context.Posts.FindAsync(postId) == null) throw new Exception("No post with this ID was found.");

				return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<ICollection<Comment>> GetByUserIdAsync(int userId)
		{
			try
			{
				if (await _context.Users.FindAsync(userId) == null) throw new Exception("No user with this ID was found.");

				return await _context.Comments.Where(c => c.UserId == userId).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<ICollection<Comment>> GetRepliedCommentsAsync(int commentId)
		{
			try
			{
				if (await _context.Comments.FindAsync(commentId) == null) throw new Exception("No comment with this ID was found.");

				return await _context.Comments.Where(c => c.ReplyToId == commentId).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Comment> UpdateAsync(Comment comment)
		{
			try
			{
				if (await _context.Comments.FindAsync(comment) == null) throw new Exception("No comment was found.");

				_context.Comments.Update(comment);
				await _context.SaveChangesAsync();
				
				return comment;
			}
			catch
			{
				throw;
			}
		}
	}
}
