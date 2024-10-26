using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
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
		private readonly IUserService _userService;

		public PostService(IPostRepository postRepository, IMapper mapper, IUserService userService)
		{
			_postRepository = postRepository;
			_mapper = mapper;
			_userService = userService;
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
					ImgUrl = blogPostRequest.ImgUrl,
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

		public async Task<PagedList<PostModel>> GetAllAsync(PostParameters queryStringParameters)
		{
			try
			{
				var posts = await _postRepository.GetAllAsync(queryStringParameters);
				var pagedPosts = _mapper.Map<PagedList<PostModel>>(posts);

				for (int i = 0; i < posts.Count; ++i)
				{
					var user = await _userService.GetById((int)posts[i].UserId);
					pagedPosts[i].Author = new()
                    {
                        Id = user.Id,
                        UserEmail = user.Email,
                        UserName = user.FullName,
                        Role = user.Role,
                    }; ;
				}

				return new PagedList<PostModel>(
					pagedPosts,
					posts.TotalCount,
					posts.CurrentPage,
					posts.PageSize
				);
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
				var author = await _userService.GetById((int) post.UserId);

				var mappedPost = _mapper.Map<PostModel>(post);

				mappedPost.Author = new()
				{
					Id = author.Id,
					UserEmail = author.Email,
					UserName = author.FullName,
					Role = author.Role,
				};

				return mappedPost;
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
