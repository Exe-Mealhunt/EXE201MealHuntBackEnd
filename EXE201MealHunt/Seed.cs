using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;

namespace MealHunt_APIs
{
    public class Seed
    {
        private readonly MealHuntContext _context;

        public Seed(MealHuntContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if(!_context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Pantry Essentials",
                        CreatedAt = DateTime.UtcNow,
                        Status = 0
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Vegetables & Greens",
                        CreatedAt = DateTime.UtcNow,
                        Status = 0
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Mushrooms",
                        CreatedAt = DateTime.UtcNow,
                        Status = 0
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Fruits",
                        CreatedAt = DateTime.UtcNow,
                        Status = 0
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Nuts & Seeds",
                        CreatedAt = DateTime.UtcNow,
                        Status = 0
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Cheeses",
                        CreatedAt = DateTime.UtcNow,
                        Status = 0
                    }
                };
                _context.Categories.AddRange(categories);
            }

            if (!_context.SubscriptionPlans.Any())
            {
                var subscriptionPlans = new List<SubscriptionPlan>
                {
                    new SubscriptionPlan
                    {
                        Name = "Bronze Member",
                        Currency = "VND",
                        Price = 10000,
                        Description = "Membership...",
                        DurationInDays = 30
                    }
                };
                _context.SubscriptionPlans.AddRange(subscriptionPlans);
            }

            if (!_context.Ingredients.Any())
            {

            }

            if (!_context.Occasions.Any())
            {

            }

            if (!_context.Recipes.Any())
            {

            }

            _context.SaveChanges();
        }
    }
}
