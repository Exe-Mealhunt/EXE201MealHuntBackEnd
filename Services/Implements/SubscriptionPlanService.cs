using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;

namespace MealHunt_Services.Implements;

public class SubscriptionPlanService : ISubscriptionPlanService
{
    private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
    private readonly IMapper _mapper;

    public SubscriptionPlanService(ISubscriptionPlanRepository subscriptionPlanRepository, IMapper mapper)
    {
        _subscriptionPlanRepository = subscriptionPlanRepository;
        _mapper = mapper;
    }

    public async Task<List<SubscriptionPlanModel>> GetSubscriptionPlansAsync()
    {
        try
        {
            var plans = await _subscriptionPlanRepository.GetSubscriptionPlansAsync();
            var response = _mapper.Map<List<SubscriptionPlanModel>>(plans);
            return response;
        }
        catch
        {
            throw;
        }
    }
}