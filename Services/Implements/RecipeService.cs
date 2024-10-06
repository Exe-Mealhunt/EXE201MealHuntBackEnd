using AutoMapper;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<RecipeModel> GetRecipeDetails(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException("Invalid Id!");
            try
            {
                var recipe = await _recipeRepository.GetRecipeById(id);
                if (recipe == null)
                    throw new Exception($"Recipe with id {id} not found! (RecipeService/GetRecipeDetails)");
                var response = _mapper.Map<RecipeModel>(recipe);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
