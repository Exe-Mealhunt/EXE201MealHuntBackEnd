using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
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
		Task<List<PostModel>> GetAllAsync();
	}
}
