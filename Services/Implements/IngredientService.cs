using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Implements;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using MealHunt_Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        private readonly IIngredientCategoryService _ingredientCategoryService;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper, IIngredientCategoryService ingredientCategoryService)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _ingredientCategoryService = ingredientCategoryService;
        }

		public async Task<IngredientRequest> AddIngredient(IngredientRequest ingredientRequest)
		{
			try
            {
                Ingredient ingredientModel = new()
                {
                    IngredientName = ingredientRequest.IngredientName,
					CreatedAt = DateTime.UtcNow,
				};

                var addedIngredient = await _ingredientRepository.AddIngredient(ingredientModel);
                await _ingredientCategoryService.AddAllByIdAsync(addedIngredient, ingredientRequest.CategoryIds);
                
                return ingredientRequest;
            }
            catch
            {
                throw;
            }
		}

		public async Task<List<IngredientModel>> GetIngredientsAsync(string searchValue)
        {
            try
            {
                var ingredients = await _ingredientRepository.GetIngredientsAsync(searchValue);
                var ingredientModel = _mapper.Map<List<IngredientModel>>(ingredients);
                return ingredientModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
