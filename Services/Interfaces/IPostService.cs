using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
	public interface IPostService
	{
		Task<Post> AddPost(BlogPostRequest blogPostRequest);
		Task<PostModel> AddAsync(PostModel post);
		Task<PostModel> UpdateAsync(PostModel post);
		Task DeleteAsync(int id);
		Task<PostModel> GetByIdAsync(int id);
		Task<PagedList<PostModel>> GetAllAsync(PostParameters pagingProperties);
	}
}
