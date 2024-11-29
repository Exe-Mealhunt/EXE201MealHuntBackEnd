namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public class ShoppingListsUserProfileResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImgUrl { get; set; }
        public List<IngredientUnitQuantityShoppingListResponse> IngredientUnits { get; set; }
    }
}
