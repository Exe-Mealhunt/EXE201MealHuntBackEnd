namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public record ResultResponse(
    int error,
    String message,
    object? data
);
}
