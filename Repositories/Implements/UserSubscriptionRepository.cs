using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class UserSubscriptionRepository : IUserSubscriptionRepository
    {
        private readonly MealHuntContext _context;

        public UserSubscriptionRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserSubscription userSubscription)
        {
            try
            {
                await _context.UserSubscriptions.AddAsync(userSubscription);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
