using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Entities
{
    public class UserSubscription
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }

        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public int? SubscriptionPlanId { get; set; }

        public virtual SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
