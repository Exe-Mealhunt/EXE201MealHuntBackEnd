namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public class GetSavedRecipeResponse
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public string? ImageUrl { get; set; }
        public string? RecipeName { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
