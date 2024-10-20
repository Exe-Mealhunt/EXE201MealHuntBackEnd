using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IMapper _mapper;

		public CommentService(ICommentRepository commentRepository, IMapper mapper)
		{
			_commentRepository = commentRepository;
			_mapper = mapper;
		}

		public async Task DeleteComment(int id)
		{
			try
			{
				await _commentRepository.DeleteAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task EditComment(CommentRequest commentRequest)
		{
			try
			{
				Comment c = new()
				{
					UserId = commentRequest.UserId,
					Content = commentRequest.Content,
					PostId = commentRequest.PostId,
					ReplyToId = commentRequest.ReplyToId,
					CreatedAt = DateTime.UtcNow,
				};

				await _commentRepository.UpdateAsync(c);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task PostComment(CommentRequest commentRequest)
		{
			try
			{
				Comment c = new()
				{
					UserId = commentRequest.UserId,
					Content = commentRequest.Content,
					PostId = commentRequest.PostId,
					ReplyToId = commentRequest.ReplyToId,
					CreatedAt = DateTime.UtcNow,
				};

				await _commentRepository.AddAsync(c);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<ICollection<CommentModel>> GetPostComments(int postId)
		{
			try
			{
				var comments = await _commentRepository.GetByPostIdAsync(postId);
				return _mapper.Map<ICollection<CommentModel>>(comments);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<ICollection<CommentModel>> GetRepliedComments(int commentId)
		{
			try
			{
				var comments = await _commentRepository.GetRepliedCommentsAsync(commentId);
				return _mapper.Map<ICollection<CommentModel>>(comments);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<ICollection<CommentModel>> GetUserComments(int userId)
		{
			try
			{
				var comments = await _commentRepository.GetByUserIdAsync(userId);
				return _mapper.Map<ICollection<CommentModel>>(comments);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
