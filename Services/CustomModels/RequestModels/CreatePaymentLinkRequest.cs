using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.RequestModels
{
    public class CreatePaymentLinkRequest
    {
        public string ProductName {  get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ReturnUrl { get; set; }

        public string CancelUrl { get; set; }
    }
}
