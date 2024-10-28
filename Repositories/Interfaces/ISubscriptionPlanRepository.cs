using MealHunt_Repositories.Entities;

namespace MealHunt_Repositories.Interfaces;

public interface ISubscriptionPlanRepository
{
    Task<SubscriptionPlan?> GetSubscriptionPlanByIdAsync(int id);
    
    Task<List<SubscriptionPlan>> GetSubscriptionPlansAsync();
}