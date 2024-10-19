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
    public interface IIngredientService
    {
        Task<List<IngredientModel>> GetIngredientsAsync(string searchValue);
        Task<IngredientRequest> AddIngredient(IngredientRequest ingredient);
    }
}
