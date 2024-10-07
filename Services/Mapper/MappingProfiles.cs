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
            CreateMap<UserModel, LoginResponse>();

            // Recipes
            CreateMap<Recipe, RecipeModel>().ReverseMap();

            // Ingredients
            CreateMap<Ingredient, IngredientModel>().ReverseMap();

            // Posts
            CreateMap<Post, PostModel>().ReverseMap();

            // Categories
            CreateMap<Category, CategoryModel>().ReverseMap();

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
            
            // Saved recipes
            CreateMap<SavedRecipe, SavedRecipeModel>().ReverseMap();
            
            // Ingredient categories
            CreateMap<IngredientCategory, IngredientCategoryModel>().ReverseMap();
            
        }
    }
}
