using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly ILogger<UserController> _logger;	

		public UserController(IUserService userService, ILogger<UserController> logger)
		{
			_userService = userService;
			_logger = logger;
		}

		[HttpGet("by-email")]
		public async Task<IActionResult> GetByEmail(string email)
		{
			try
			{
				var user = await _userService.GetByEmail(email);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpGet("by-id")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var user = await _userService.GetById(id);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddUser([FromBody] UserRequest user)
		{
			try
			{
				await _userService.AddUser(user);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = ex.Message });
			}
		}
	}
}
