using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategories();
    }
}
