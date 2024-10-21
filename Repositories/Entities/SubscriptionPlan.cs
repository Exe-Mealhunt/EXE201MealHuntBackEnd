using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; } = "VND";

        public long DurationInDays { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<UserSubscription>? UserSubscriptions { get; set; } = new List<UserSubscription>();

    }
}
