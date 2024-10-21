using MealHunt_Repositories.Pagination;
using MealHunt_Services.CustomModels.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MealHunt_APIs.ViewModels.ResponseModel
{
	public class PostPagingResponse
	{
		public PagedList<PostListResponse> Posts { get; set; }

		public int CurrentPage { get; set; }

		public int TotalPages { get; set; }

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public bool HasPrevious { get; set; }

		public bool HasNext { get; set; }
	}
}
