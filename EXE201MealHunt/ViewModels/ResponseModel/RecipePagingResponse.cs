using MealHunt_Repositories.Pagination;
using MealHunt_Services.CustomModels.ResponseModels;

namespace MealHunt_APIs.ViewModels.ResponseModel
{
    public class RecipePagingResponse
    {
        public PagedList<RecipeListResponse> Recipes {  get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasPrevious {  get; set; }

        public bool HasNext { get; set; }

    }
}
