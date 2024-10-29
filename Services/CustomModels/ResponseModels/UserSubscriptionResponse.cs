using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
    public class UserSubscriptionResponse
    {
        public int? SubscriptionPlanId { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
