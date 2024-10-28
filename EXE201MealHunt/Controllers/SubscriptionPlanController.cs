using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.Controllers;

[ApiController]
[Route("api/subscription-plans")]
public class SubscriptionPlanController : ControllerBase
{
    private readonly ILogger<SubscriptionPlanController> _logger;
    private readonly ISubscriptionPlanService _subscriptionPlanService;

    public SubscriptionPlanController(ILogger<SubscriptionPlanController> logger, ISubscriptionPlanService subscriptionPlanService)
    {
        _logger = logger;
        _subscriptionPlanService = subscriptionPlanService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSubscriptionPlans()
    {
        try
        {
            var response = await _subscriptionPlanService.GetSubscriptionPlansAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}