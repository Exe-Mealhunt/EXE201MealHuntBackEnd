using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Pagination;
using MealHunt_Repositories.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
	public interface IPostRepository
	{
		Task<Post> AddAsync(Post post);
		Task<Post> UpdateAsync(Post post);
		Task<Post> DeleteAsync(int id);
		Task<PagedList<Post>> GetAllAsync(PostParameters queryStringParameters);
		Task<Post> FindByIdAsync(int id);
	}
}
