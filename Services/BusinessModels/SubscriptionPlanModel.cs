using Newtonsoft.Json;

namespace MealHunt_Services.BusinessModels;

public class SubscriptionPlanModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public string Currency { get; set; } = "VND";

    public long DurationInDays { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public List<UserSubscriptionModel>? UserSubscriptions { get; set; } = new List<UserSubscriptionModel>();
}