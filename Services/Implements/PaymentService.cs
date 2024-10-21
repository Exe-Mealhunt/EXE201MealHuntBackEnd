using Azure;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Net.payOS;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserRepository _userRepository;
        private string prefix = "User";
        private string subscriptionPrefix = "Plan";
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;

        public PaymentService(PayOS payOS, IPaymentRepository paymentRepository, IUserRepository userRepository, IUserSubscriptionRepository userSubscriptionRepository)
        {
            _payOS = payOS;
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
        }

        public async Task<string> CreatePaymentUrl(CreatePaymentLinkRequest request)
        {
            try
            {
                //int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                long ticks = DateTime.UtcNow.Ticks; // This gives you a unique value in ticks
                int randomValue = new Random().Next(1000, 9999);
                long orderCode = (long)(ticks % 1000000000 + randomValue);
                ItemData item = new ItemData(request.ProductName, 1, request.Price);
                List<ItemData> items = new List<ItemData>();
                items.Add(item);

                var description = $"{prefix}{request.UserId} {subscriptionPrefix}{request.SubscriptionPlanId}";
                PaymentData paymentData = 
                    new PaymentData(orderCode, request.Price, description, items, request.CancelUrl, request.ReturnUrl, null, request.UserId.ToString());

                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                return createPayment.checkoutUrl;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PayOSWebhookResponse> PaymentExecute(WebhookType webhook)
        {
            try
            {
                WebhookData data = _payOS.verifyPaymentWebhookData(webhook);

                // Check payment existed by transaction id
                if (await _paymentRepository.IsExistedByTransactionId(data.reference))
                    return new PayOSWebhookResponse
                    {
                        Success = true
                    };

                if (data.description == "Ma giao dich thu nghiem" || data.description == "VQRIO123")
                {
                    return new PayOSWebhookResponse
                    {
                        Success = true
                    };
                }

                // Create payment
                var orderCode = data.orderCode.ToString();
                var amount = (double)data.amount;
                var payDateString = data.transactionDateTime;

                // Parse the string to DateTime (assumes the string is in local time)
                DateTime localDateTime = DateTime.Parse(payDateString, CultureInfo.InvariantCulture);

                // Convert to UTC
                DateTime utcDateTime = localDateTime.ToUniversalTime();

                var transactionId = data.reference;

                // Get user id from description
                var description = data.description;
                var descriptionParts = description.Split(' ');
                var userId = int.Parse(descriptionParts[0].Substring(prefix.Length));
                var planId = int.Parse(descriptionParts[1].Substring(subscriptionPrefix.Length));

                // Check if user is existed
                var user = await _userRepository.FindUserById(userId);
                if(user == null)
                    return new PayOSWebhookResponse
                    {
                        Success = false
                    };

                var payment = new Payment
                {
                    Id = orderCode,
                    Amount = amount,
                    PayDate = utcDateTime,
                    TransactionId = transactionId,
                    UserId = userId
                };

                // Save new payment
                var response = await _paymentRepository.AddPayment(payment);

                // Create UserSubscription
                var userSubscription = new UserSubscription
                {
                    StartDate = utcDateTime,
                    EndDate = utcDateTime.AddDays(30),
                    IsCurrent = true,
                    UserId = userId,
                    SubscriptionPlanId = planId
                };
                await _userSubscriptionRepository.AddAsync(userSubscription);

                if(String.IsNullOrEmpty(response))
                    return new PayOSWebhookResponse
                    {
                        Success = false
                    };

                return new PayOSWebhookResponse
                {
                    Success = true
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
