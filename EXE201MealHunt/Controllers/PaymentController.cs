using Azure;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using System;
using MealHunt_Services.CustomModels.ResponseModels;
using MealHunt_APIs.ViewModels.ResponseModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Guest,Member")]
        public async Task<IActionResult> CreatePaymentUrl(CreatePaymentLinkRequest request)
        {
            try
            {
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                var userId = Int32.Parse(userIdClaim.Value.Trim());
                request.UserId = userId;
                var response = await _paymentService.CreatePaymentUrl(request);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PaymentCallBack(WebhookType body)
        {
            if (body == null)
                return BadRequest("Request data body is required!");
            try
            {
                var response = await _paymentService.PaymentExecute(body);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
