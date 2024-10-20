namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public class ShoppingListsUserProfileResponse
    {
        public string? Name { get; set; }
        public List<IngredientUnitQuantityShoppingListResponse> IngredientUnits { get; set; }
    }
}
