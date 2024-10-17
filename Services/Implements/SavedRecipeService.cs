using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using MealHunt_Services.Mapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class SavedRecipeService : ISavedRecipeService
    {
        private readonly ISavedRecipeRepository _savedRecipeRepository;
        private readonly IMapper _mapper;

        public SavedRecipeService(ISavedRecipeRepository savedRecipeRepository, IMapper mapper)
        {
            _savedRecipeRepository = savedRecipeRepository;
            _mapper = mapper;
        }
        public async Task<SavedRecipeModel> AddSavedRecipe(int recipeId, int userId)
        {
            var savedRecipeModel = new SavedRecipeModel
            {
                RecipeId = recipeId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };
            var savedRecipe = _mapper.Map<SavedRecipe>(savedRecipeModel);
            var savedRecipeResponse = await _savedRecipeRepository.AddSavedRecipe(savedRecipe);
            var response = _mapper.Map<SavedRecipeModel>(savedRecipeResponse);
            return response;
        }
    }
}
