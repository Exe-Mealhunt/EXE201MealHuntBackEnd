﻿using MealHunt_Repositories;
using MealHunt_Repositories.Implements;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.Implements;
using MealHunt_Services.Interfaces;

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
                .AddCorsConfiguration();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add your repositories here
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add your services here
            services.AddScoped<IUserService, UserService>();

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