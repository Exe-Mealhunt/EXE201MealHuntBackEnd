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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAll();
                categories = categories.Where(c => c.IngredientCategories.Any()).ToList();
                var response = _mapper.Map<List<CategoryModel>>(categories);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
