using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentUrl(CreatePaymentLinkRequest request);

        Task<PayOSWebhookResponse> PaymentExecute(WebhookType webhook);
    }
}
