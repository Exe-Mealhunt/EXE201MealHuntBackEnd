﻿using MealHunt_Repositories;
using MealHunt_Repositories.Implements;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.Implements;
using MealHunt_Services.Interfaces;
using MealHunt_Services.Mapper;
using System.Reflection;

namespace MealHunt_APIs.ServiceExtensions
{
    public static class ApplicationServicesExtensions
    {
        const string MyAllowSpecificOrigins = "myAllowSpecificOrigins";

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add your application services here
            services
                .AddRepositories()
                .AddServices()
                .AddCorsConfiguration()
                ;
            ;

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add your repositories here
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOccasionRepository, OccasionRepository>();
            services.AddScoped<ISavedRecipeRepository, SavedRecipeRepository>();
            services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
<<<<<<< HEAD
            services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
=======
            services.AddScoped<IIngredientCategoryRepository, IngredientCategoryRepository>();
>>>>>>> 27f284c85e828e09a1632c149230d4629411f128

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add your services here
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOccasionService, OccasionService>();
            services.AddScoped<ISavedRecipeService, SavedRecipeService>();
            services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
<<<<<<< HEAD
            services.AddScoped<IShoppingListService, ShoppingListService>();
=======
            services.AddScoped<IIngredientCategoryService, IngredientCategoryService>();
>>>>>>> 27f284c85e828e09a1632c149230d4629411f128

            return services;
        }

        private static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            // CORS config
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                        policy =>
                        {
                            policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        }
                    );
            });

            return services;
        }
    }
}
