using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.BusinessModels
{
    public partial class CategoryModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? Status { get; set; }

        public virtual List<IngredientCategoryModel> IngredientCategories { get; set; } = new List<IngredientCategoryModel>();
    }
}
