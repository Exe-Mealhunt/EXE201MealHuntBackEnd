using AutoMapper;
using MealHunt_Repositories;
using MealHunt_Services.BusinessModels;
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

            CreateMap<User, UserModel>().ReverseMap();
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
