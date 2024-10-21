using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MealHunt_Repositories.Implements
{
	public class PostRepository : IPostRepository
	{
		private readonly MealHuntContext _context;

		public PostRepository(MealHuntContext context)
		{
			_context = context;
		}

		public async Task<Post> AddAsync(Post post)
		{
			try
			{
				await _context.AddAsync(post);
				await _context.SaveChangesAsync();

				return post;
			}
			catch
			{
				throw;
			}
		}

		public async Task<Post> DeleteAsync(int id)
		{
			try
			{
				var post = await _context.Posts.FindAsync(id) ?? throw new Exception("No post with this id");
				
				_context.Posts.Remove(post);
				await _context.SaveChangesAsync();
				
				return post;
			}
			catch
			{
				throw;
			}
		}

		public async Task<Post> FindByIdAsync(int id)
		{
			try
			{
				var post = await _context.Posts
								.Include(p => p.User)
								.Include(p => p.Comments)
								.FirstOrDefaultAsync(p => p.Id == id);

				return post;
			}
			catch
			{
				throw;
			}
		}

		public async Task<PagedList<Post>> GetAllAsync(PostParameters queryStringParameters)
		{
			try
			{
				var posts = _context.Posts
							.Include(p => p.Comments)
							.Include(p => p.User)
							.AsQueryable();

				return await PagedList<Post>
							.ToPagedList(posts, queryStringParameters.PageNumber, queryStringParameters.PageSize);
			}
			catch
			{
				throw;
			}
		}

		public async Task<Post> UpdateAsync(Post post)
		{
			try
			{
				if (await _context.Posts.FindAsync(post.Id) == null) throw new Exception("No post with this id");
				
				_context.Posts.Update(post);
				await _context.SaveChangesAsync();
				
				return post;
			}
			catch
			{
				throw;
			}
		}
	}
}