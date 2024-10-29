namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public class IngredientShoppingListResponse
    {
        public int Id { get; set; }

        public int? IngredientId { get; set; }

        public int? ShoppingListsId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? Status { get; set; }
    }
}
