using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealHunt_Repositories.Implements;

public class SubscriptionPlanRepository : ISubscriptionPlanRepository
{
    private readonly MealHuntContext _context;

    public SubscriptionPlanRepository(MealHuntContext context)
    {
        _context = context;
    }
    
    public async Task<SubscriptionPlan?> GetSubscriptionPlanByIdAsync(int id)
    {
        return await _context.SubscriptionPlans.FirstOrDefaultAsync(sp => sp.Id == id);
    }

    public async Task<List<SubscriptionPlan>> GetSubscriptionPlansAsync()
    {
        var plans = new List<SubscriptionPlan>();
        try
        {
            plans = await _context.SubscriptionPlans.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return plans;
    }
}