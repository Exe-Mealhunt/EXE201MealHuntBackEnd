using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface IIngredientCategoryRepository
    {
        Task AddAsync(IngredientCategory ingredientCategory);
        Task AddAllAsync(ICollection<IngredientCategory> ingredientCategories);
    }
}
