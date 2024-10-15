using MealHunt_Services.CustomModels.ResponseModels;

namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public class RecipeDetailsPageResponse
    {
        public RecipeDetailsResponse Recipe {  get; set; }

        public List<Ingredient4RecipeDetails> MissingIngredients { get; set; }
    }
}
