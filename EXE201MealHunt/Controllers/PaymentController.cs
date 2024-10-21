using Azure;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using System;
using MealHunt_Services.CustomModels.ResponseModels;
using MealHunt_APIs.ViewModels.ResponseModel;

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
        public async Task<IActionResult> CreatePaymentUrl(CreatePaymentLinkRequest request)
        {
            try
            {
                //int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                //ItemData item = new ItemData(request.ProductName, 1, request.Price);
                //List<ItemData> items = new List<ItemData>();
                //items.Add(item);
                //PaymentData paymentData = new PaymentData(orderCode, request.Price, request.Description, items, request.CancelUrl, request.ReturnUrl);

                //CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                //return Ok(createPayment);

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

        [HttpGet]
        public async Task<IActionResult> Test()
        {

            try
            {
                return Ok(new PayOSWebhookResponse
                {
                    Success = true,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
