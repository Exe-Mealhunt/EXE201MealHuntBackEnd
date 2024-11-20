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
using Microsoft.AspNetCore.Identity;

namespace MealHunt_Services.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserRepository _userRepository;
        private string prefix = "Meal Hunt - Payment of #";
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private string updateRole = "Member";
        private string guestRole = "Guest";


        public PaymentService(
            PayOS payOS, 
            IPaymentRepository paymentRepository, 
            IUserRepository userRepository, 
            IUserSubscriptionRepository userSubscriptionRepository, 
            ISubscriptionPlanRepository subscriptionPlanRepository,
            UserManager<User> userManager,
            RoleManager<Role> roleManager
            )
        {
            _payOS = payOS;
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> CreatePaymentUrl(CreatePaymentLinkRequest request)
        {
            try
            {
                //int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                long ticks = DateTime.UtcNow.Ticks; // This gives you a unique value in ticks
                int randomValue = new Random().Next(1000, 9999);
                long orderCode = (long)(ticks % 1000000000 + randomValue);
                
                // Get subscription plan 
                var plan = await _subscriptionPlanRepository.GetSubscriptionPlanByIdAsync((int)request.SubscriptionPlanId);
                if (plan == null)
                {
                    throw new Exception($"Subscription plan with id {request.SubscriptionPlanId} not found!");
                }
                
                ItemData item = new ItemData(plan.Name, 1, (int)plan.Price);
                List<ItemData> items = new List<ItemData>();
                items.Add(item);

                var description = $"{prefix}{request.UserId}S{plan.Id}";
                PaymentData paymentData = 
                    new PaymentData(orderCode, (int)plan.Price, description, items, request.CancelUrl, request.ReturnUrl);

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
                var descriptionParts = description.Split('#');
                var orderInfoStrings = descriptionParts[1].Split('S');
                var userId = int.Parse(orderInfoStrings[0]);
                var planId = int.Parse(orderInfoStrings[1]);
                
                // Get subscription plan by id
                var plan = await _subscriptionPlanRepository.GetSubscriptionPlanByIdAsync(planId);
                if(plan == null)
                    return new PayOSWebhookResponse
                    {
                        Success = false
                    };
                double durationInDays = (double)plan.DurationInDays;
                
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
                    EndDate = utcDateTime.AddDays(durationInDays),
                    IsCurrent = !await _userRepository.IsInOtherPlans(userId),
                    UserId = userId,
                    SubscriptionPlanId = planId
                };
                await _userSubscriptionRepository.AddAsync(userSubscription);

                if(String.IsNullOrEmpty(response))
                    return new PayOSWebhookResponse
                    {
                        Success = false
                    };
                
                // Update role of user from Guest to Member
                if (user.Role.Equals(guestRole))
                {
                    await ChangeUserRole(user, updateRole);
                }

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
        
        private async Task ChangeUserRole(User user, string newRole)
        {
            // Check if the new role exists
            if (!await _roleManager.RoleExistsAsync(newRole))
            {
                throw new Exception("Invalid role");
            }

            // Get current roles of the user
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Remove all current roles
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                throw new Exception("Failed to remove existing roles.");
            }

            // Add the new role
            var addResult = await _userManager.AddToRoleAsync(user, newRole);
            if (!addResult.Succeeded)
            {
                throw new Exception("Failed to add new role.");
            }
            
            // Update role property (string) of user
            user.Role = newRole;
            await _userManager.UpdateAsync(user);
        }
    }
}
