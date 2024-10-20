using Azure;
using MealHunt_Services.CustomModels.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using System;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly PayOS _payOS;

        public PaymentController(ILogger<PaymentController> logger, PayOS payOS)
        {
            _logger = logger;
            _payOS = payOS;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePaymentUrl(CreatePaymentLinkRequest request)
        {
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                ItemData item = new ItemData(request.ProductName, 1, request.Price);
                List<ItemData> items = new List<ItemData>();
                items.Add(item);
                PaymentData paymentData = new PaymentData(orderCode, request.Price, request.Description, items, request.CancelUrl, request.ReturnUrl);

                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                return Ok(createPayment);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PaymentCallBack()
        {
            return Ok(Request.Query);
        }
    }
}
