using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
	[ApiController]
	[Route("api/comments")]
	public class CommentController : ControllerBase
	{
		private readonly ICommentService _commentService;
		private readonly ILogger<CommentController> _logger;

		public CommentController(ICommentService commentService, ILogger<CommentController> logger)
		{
			_commentService = commentService;
			_logger = logger;
		}

		[HttpGet("/user/{id}")]
		public async Task<IActionResult> GetByUserId(int id) 
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var response = await _commentService.GetUserComments(id);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpGet("/post/{id}")]
		public async Task<IActionResult> GetByPostId(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var response = await _commentService.GetPostComments(id);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpGet("/reply/{id}")]
		public async Task<IActionResult> GetByCommentId(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var response = await _commentService.GetRepliedComments(id);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddComment([FromBody] CommentRequest commentRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				if (commentRequest == null) return BadRequest("Comment is null.");
				if (string.IsNullOrEmpty(commentRequest.Content)) return BadRequest("Comment can not be blank.");

				await _commentService.PostComment(commentRequest);
				return Ok(commentRequest);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpPut]
		public async Task<IActionResult> EditComment([FromBody] CommentRequest commentRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				if (commentRequest == null) return BadRequest("Comment is null.");
				if (string.IsNullOrEmpty(commentRequest.Content)) return BadRequest("Comment can not be blank.");

				await _commentService.EditComment(commentRequest);
				return Ok(commentRequest);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleComment(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				await _commentService.DeleteComment(id);
				return Ok("Comment deleted.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}
	}
}
