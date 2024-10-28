using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;

namespace MealHunt_Services.Interfaces;

public interface ISubscriptionPlanService
{
    Task<List<SubscriptionPlanModel>> GetSubscriptionPlansAsync();
}