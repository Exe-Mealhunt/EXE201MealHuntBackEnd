using AutoMapper;
using MealHunt_Repositories;
using MealHunt_Repositories.Entities;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Example 
            //CreateMap<User, UserModel>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToUserModelStatus(src.Status)))
            //    .ReverseMap()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToUserStatus(src.Status)));

            // Users
            CreateMap<User, UserModel>().ReverseMap();
            //CreateMap<RegisterRequest, User>()
            //    .ConstructUsing(src => new User())
            //    //.ForMember(dest => dest.Id, opt => opt.Ignore())
            //    //.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // If `CreatedAt` is set elsewhere
            //    //.ForMember(dest => dest.Role, opt => opt.Ignore())       // If `Role` is set elsewhere
            //    //.ForMember(dest => dest.Status, opt => opt.Ignore())     // If `Status` is set elsewhere
            //    //.ForMember(dest => dest.Comments, opt => opt.Ignore())   // Since Comments are not part of the request
            //    //.ForMember(dest => dest.Posts, opt => opt.Ignore())      // Ignore Posts
            //    //.ForMember(dest => dest.SavedRecipes, opt => opt.Ignore()) // Ignore SavedRecipes
            //    //.ForMember(dest => dest.ShoppingLists, opt => opt.Ignore())
            //    ;
            CreateMap<RegisterRequest, User>()
                .ConstructUsing(src => new User());
            CreateMap<RegisterRequest, UserModel>()
                .ConstructUsing(src => new UserModel());
            CreateMap<User, RegisterResponse>();
            CreateMap<User, LoginResponse>();

            // Recipes
            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<Recipe, RecipeDetailsResponse>()
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => RecipeIngredientsToIngredients(src.RecipeIngredients)))
                .ForMember(dest => dest.OccasionName, opt => opt.MapFrom(src => src.Occasion == null ? null : src.Occasion.Name));
            CreateMap<Recipe, RecipeListResponse>()
                .ForMember(dest => dest.OccasionName, opt => opt.MapFrom(src => src.Occasion == null ? null : src.Occasion.Name));

            // Ingredients
            CreateMap<Ingredient, IngredientModel>().ReverseMap();
            CreateMap<Ingredient, Ingredient4RecipeDetails>();

            // RecipeIngredients
            CreateMap<RecipeIngredient, RecipeIngredientModel>().ReverseMap();

            // Posts
            CreateMap<Post, PostModel>().ReverseMap();

            // Categories
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryWithIngredientsResponse>()
                .ForMember(dest => dest.IngredientNames, opt => opt.MapFrom(src => IngredientCategoriesToIngredientNames(src.IngredientCategories)));

            // Occasions
            CreateMap<Occasion, OccasionModel>().ReverseMap();

            // Comments
            CreateMap<Comment, CommentModel>().ReverseMap();

            // Shopping lists
            CreateMap<ShoppingList, ShoppingListModel>().ReverseMap();

            // Ingredient shopping lists
            CreateMap<IngredientShoppingList, IngredientShoppingListModel>().ReverseMap();
            
            // Recipe ingredients
            CreateMap<RecipeIngredient, RecipeIngredientModel>().ReverseMap();
            CreateMap<RecipeIngredient, Ingredient4RecipeDetails>()
                .ForMember(dest => dest.IngredientName, opt => opt.MapFrom(src => src.Ingredient.IngredientName))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => IngredientCategoriesToCategoryNames(src.Ingredient.IngredientCategories)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId));

            // Saved recipes
            CreateMap<SavedRecipe, SavedRecipeModel>().ReverseMap();
            
            // Ingredient categories
            CreateMap<IngredientCategory, IngredientCategoryModel>().ReverseMap();

			CreateMap<Post, PostListResponse>();
		}

        private List<string> IngredientCategoriesToIngredientNames(ICollection<IngredientCategory> ingredientCategories)
        {
            var ingredientNames = new List<string>();

            if(ingredientCategories != null && ingredientCategories.Any())
            {
                foreach (IngredientCategory ingredientCategory in ingredientCategories.ToList())
                {
                    ingredientNames.Add(ingredientCategory.Ingredient.IngredientName);
                }
            }

            return ingredientNames;
        }

        private List<Ingredient4RecipeDetails> RecipeIngredientsToIngredients(ICollection<RecipeIngredient> recipeIngredients)
        {
            var ingredients = new List<Ingredient4RecipeDetails>();

            if (recipeIngredients != null && recipeIngredients.Any())
            {
                foreach (RecipeIngredient recipeIngredient in recipeIngredients.ToList())
                {
                    var ingredient = new Ingredient4RecipeDetails
                    {
                        Id = (int)recipeIngredient.IngredientId,
                        IngredientName = recipeIngredient.Ingredient.IngredientName,
                        Quantity = recipeIngredient.Quantity,
                        Unit = recipeIngredient.Unit,
                        CategoryNames = recipeIngredient.Ingredient.IngredientCategories
                            .Select(ic => ic.Category.Name).ToList()
                    };
                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }

        private List<string> IngredientCategoriesToCategoryNames(ICollection<IngredientCategory> ingredientCategories)
        {
            var categoryNames = new List<string>();

            if (ingredientCategories != null && ingredientCategories.Any())
            {
                foreach (IngredientCategory ingredientCategory in ingredientCategories.ToList())
                {
                    categoryNames.Add(ingredientCategory.Category.Name);
                }
            }

            return categoryNames;
        }
    }
}
