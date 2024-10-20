using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Implements;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
	[ApiController]
	[Route("api/blog")]
	public class BlogController : ControllerBase
	{
		private readonly IPostService _postService;
		private readonly ILogger<BlogController> _logger;

		public BlogController(IPostService postService, ILogger<BlogController> logger)
		{
			_postService = postService;
			_logger = logger;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var response = await _postService.GetAllAsync();
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var response = await _postService.GetByIdAsync(id);
				if (response == null) return BadRequest("No blog with this ID was found.");
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddBlogPost([FromBody] BlogPostRequest blogPostRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				if (blogPostRequest == null) return BadRequest("Body is null.");
				if (string.IsNullOrEmpty(blogPostRequest.Title) || string.IsNullOrEmpty(blogPostRequest.Content))
				{
					return BadRequest("Title and content can not be empty.");
				}

				await _postService.AddPost(blogPostRequest);
				return Ok(blogPostRequest);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		/*
		[HttpPost]
		public async Task<IActionResult> AddPostAsync([FromBody] PostModel postModel)
		{
			if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			try
			{
				if (postModel == null) return BadRequest("Body is null.");
				if (string.IsNullOrEmpty(postModel.Title) || string.IsNullOrEmpty(postModel.Content))
				{
					return BadRequest("Title and content can not be empty.");
				}

				await _postService.AddAsync(postModel);
				return Ok(postModel);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}
		*/

		[HttpPut]
		public async Task<IActionResult> UpdatePost([FromBody] PostModel postModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				if (postModel == null) return BadRequest("Body is null.");
				if (string.IsNullOrEmpty(postModel.Title) || string.IsNullOrEmpty(postModel.Content))
				{
					return BadRequest("Title and content can not be empty.");
				}

				await _postService.UpdateAsync(postModel);
				return Ok(postModel);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePost(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var post = await _postService.GetByIdAsync(id);
				if (post == null) return BadRequest("No blog with this ID was found.");

				await _postService.DeleteAsync(id);
				return Ok(post);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}
	}
}
