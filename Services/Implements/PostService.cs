using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
	public class PostService : IPostService
	{
		private readonly IPostRepository _postRepository;
		private readonly IMapper _mapper;
		private readonly ICommentService _commentService;

		public PostService(IPostRepository postRepository, IMapper mapper, ICommentService commentService)
		{
			_postRepository = postRepository;
			_mapper = mapper;	
			_commentService = commentService;
		}

		public async Task<PostModel> AddAsync(PostModel post)
		{
			try
			{
				var mappedPost = _mapper.Map<Post>(post);
				await _postRepository.AddAsync(mappedPost);

				return post;
			}
			catch
			{
				throw;
			}
		}

		public async Task<Post> AddPost(BlogPostRequest blogPostRequest)
		{
			try
			{
				Post post = new()
				{
					UserId = blogPostRequest.UserId,
					Title = blogPostRequest.Title,
					Content = blogPostRequest.Content,
					CreatedAt = DateTime.UtcNow,
				};

				await _postRepository.AddAsync(post);
				return post;
			}
			catch
			{
				throw;
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				await _postRepository.DeleteAsync(id);
			}
			catch
			{
				throw;
			}
		}

		public async Task<List<PostModel>> GetAllAsync()
		{
			try
			{
				var posts = await _postRepository.GetAllAsync();
				var mappedPosts = _mapper.Map<List<PostModel>>(posts);
				return mappedPosts;
			}
			catch
			{
				throw;
			}
		}

		public async Task<PostModel> GetByIdAsync(int id)
		{
			try
			{
				var post = await _postRepository.FindByIdAsync(id);
				
				return _mapper.Map<PostModel>(post);
			}
			catch
			{
				throw;
			}
		}

		public Task<PostModel> UpdateAsync(PostModel post)
		{
			throw new NotImplementedException();
		}
	}
}
