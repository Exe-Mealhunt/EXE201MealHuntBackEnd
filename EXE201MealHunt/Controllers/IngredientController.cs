﻿using MealHunt_APIs.ViewModels.ResponseModel;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MealHunt_APIs.Controllers
{
    [ApiController]
    [Route("api/ingredient")]
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet("get-ingredients")]
        public async Task<IActionResult> GetIngredientsAsync(string value = null)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ingredientModels = await _ingredientService.GetIngredientsAsync(value);
                var response = ingredientModels.Select(i => new IngredientsResponse
                {
                    Id = i.Id,
                    IngredientName = i.IngredientName,
                    CategoryNames = i.IngredientCategories.Select(ic => ic.Category.Name).ToList()
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] IngredientRequest ingredientRequest)
        {
            if (ingredientRequest == null)
            {
                return BadRequest("Ingredient is null");
            }
            else if (string.IsNullOrEmpty(ingredientRequest.IngredientName))
            {
				return BadRequest("Ingredient name can not be empty");
			}
            else if (ingredientRequest.CategoryIds.Count() <= 0)
            {
				return BadRequest("Ingredient must belongs to at least 1 category");
			}

            await _ingredientService.AddIngredient(ingredientRequest);
            return Ok(ingredientRequest);
        }
    }
}
