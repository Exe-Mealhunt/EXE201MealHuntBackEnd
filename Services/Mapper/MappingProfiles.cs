using AutoMapper;
using MealHunt_Repositories;
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

            // User
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<RegisterRequest, User>()
                .ConstructUsing(src => new User())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // If `CreatedAt` is set elsewhere
                .ForMember(dest => dest.Role, opt => opt.Ignore())       // If `Role` is set elsewhere
                .ForMember(dest => dest.Status, opt => opt.Ignore())     // If `Status` is set elsewhere
                .ForMember(dest => dest.Comments, opt => opt.Ignore())   // Since Comments are not part of the request
                .ForMember(dest => dest.Posts, opt => opt.Ignore())      // Ignore Posts
                .ForMember(dest => dest.SavedRecipes, opt => opt.Ignore()) // Ignore SavedRecipes
                .ForMember(dest => dest.ShoppingLists, opt => opt.Ignore()); 
            CreateMap<User, RegisterResponse>();


            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Ingredient, IngredientModel>().ReverseMap();
            CreateMap<IngredientShoppingList, IngredientShoppingListModel>().ReverseMap();
            CreateMap<Post, PostModel>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientModel>().ReverseMap();
            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<RecipeTag, RecipeTagModel>().ReverseMap();
            CreateMap<SavedRecipe, SavedRecipeModel>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListModel>().ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();
            CreateMap<Tip, TipModel>().ReverseMap();
        }
    }
}
