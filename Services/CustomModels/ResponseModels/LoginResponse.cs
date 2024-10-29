using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public UserSubscriptionResponse Subscription { get; set; }

        public string? AccessToken { get; set; }
    }
}
