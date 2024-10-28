namespace MealHunt_Services.BusinessModels;

public class UserSubscriptionModel
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsCurrent { get; set; }

    public int? UserId { get; set; }

    public UserModel? User { get; set; }

    public int? SubscriptionPlanId { get; set; }

    public SubscriptionPlanModel? SubscriptionPlan { get; set; }
}