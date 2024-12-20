﻿using System;
using System.Collections.Generic;
using MealHunt_Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MealHunt_Repositories.Data;

public partial class MealHuntContext : IdentityDbContext<User, Role, int>
{
    public MealHuntContext()
    {
    }

    public MealHuntContext(DbContextOptions<MealHuntContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }

    public virtual DbSet<IngredientShoppingList> IngredientShoppingLists { get; set; }

    public virtual DbSet<Occasion> Occasions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<SavedRecipe> SavedRecipes { get; set; }

    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-winter-forest-a1s38rnz-pooler.ap-southeast-1.aws.neon.tech;Port=5432;Username=default;Password=4xi9lNBgLVTs;Database=verceldb;");
    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();
        var connection = configuration.GetConnectionString("MealHuntDB");
        return connection;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Identity role
        base.OnModelCreating(modelBuilder);

        List<Role> roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = 2,
                    Name = "Guest",
                    NormalizedName = "GUEST"
                },
                new Role
                {
                    Id = 3,
                    Name = "Member",
                    NormalizedName = "MEMBER"
                }
            };

        modelBuilder.Entity<Role>().HasData(roles);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FD239E576");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at")
                .ValueGeneratedOnAdd();         
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");

        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3213E83FEFE461DC");

            entity.ToTable("comments");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(1)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReplyToId).HasColumnName("replyTo_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__comments__post_i__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__comments__user_i__59063A47");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingredie__3213E83F8E5F7920");

            entity.ToTable("ingredients");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .ValueGeneratedOnAdd()
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(255)
                .HasColumnName("ingredient_name");
            
            entity.Property(e => e.Status).HasColumnName("status");
            
        });

        modelBuilder.Entity<IngredientCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingredie__3213E83F52FA63E0");

            entity.ToTable("ingredientCategories");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .ValueGeneratedOnAdd()
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Category).WithMany(p => p.IngredientCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__ingredien__categ__5070F446");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientCategories)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__ingredien__ingre__4F7CD00D");
        });

        modelBuilder.Entity<IngredientShoppingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingredie__3213E83F65AF0674");

            entity.ToTable("ingredientShoppingLists");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.ShoppingListsId).HasColumnName("shoppingLists_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientShoppingLists)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__ingredien__ingre__534D60F1");

            entity.HasOne(d => d.ShoppingLists).WithMany(p => p.IngredientShoppingLists)
                .HasForeignKey(d => d.ShoppingListsId)
                .HasConstraintName("FK__ingredien__shopp__5441852A");
        });

        modelBuilder.Entity<Occasion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__occasion__3213E83F7E4E508E");

            entity.ToTable("occasions");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .ValueGeneratedOnAdd()
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83F5095F241");

            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(1)
                .HasColumnName("content");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(5000)
                .HasColumnName("img_url");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(1)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__posts__user_id__571DF1D5");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recipes__3213E83FDEC2D5E6");

            entity.ToTable("recipes");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .ValueGeneratedOnAdd()
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OccasionId).HasColumnName("occasion_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tutorial)
                .HasMaxLength(5000)
                .HasColumnName("tutorial");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Video)
                .HasMaxLength(255)
                .HasColumnName("video");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.CookingTime)
                .HasColumnName("cooking_time");

            entity.HasOne(d => d.Occasion).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.OccasionId)
                .HasConstraintName("FK__recipes__occasio__4E88ABD4");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recipeIn__3213E83FCE3B5733");

            entity.ToTable("recipeIngredients");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__recipeIng__ingre__4CA06362");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__recipeIng__recip__4D94879B");
        });

        modelBuilder.Entity<SavedRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__savedRec__3213E83F0007AF5A");

            entity.ToTable("savedRecipes");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.SavedRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__savedReci__recip__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.SavedRecipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__savedReci__user___5535A963");
        });

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shopping__3213E83F19C5C534");

            entity.ToTable("shoppingLists");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__shoppingL__recip__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__shoppingL__user___5165187F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F8682BC63");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                //.ValueGeneratedNever()
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                //.IsRowVersion()
                //.IsConcurrencyToken()
                .ValueGeneratedOnAdd()
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");

            entity.HasMany(d => d.UserSubscriptions)
                .WithOne(p => p.User)  // Assuming UserSubscription has a User navigation property
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_subscriptions__user_id__B145AAB4");

            entity.HasMany(d => d.Payments)
                .WithOne(p => p.User)  // Assuming Payment has a User navigation property
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__payments__user_id__D4A041FD");
        });

        // Subscription and Payment
        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubscriptionPlan__3213E83FFEEA542A");

            entity.ToTable("subscription_plans");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .HasColumnName("currency");

            entity.Property(e => e.DurationInDays)
                .HasColumnName("duration_in_days");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            entity.HasMany(d => d.UserSubscriptions) // Assuming the collection is correctly defined in SubscriptionPlan
                .WithOne(p => p.SubscriptionPlan) // Assuming UserSubscription has a SubscriptionPlan navigation property
                .HasForeignKey(d => d.SubscriptionPlanId) // Foreign key in UserSubscription
                .HasConstraintName("FK__user_subscriptions__subscription_plan_id__B2566202");

        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSubscription__3213E83FADFC563A");

            entity.ToTable("user_subscriptions");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.StartDate)
                //.HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                //.HasColumnType("datetime")
                .HasColumnName("end_date");

            entity.Property(e => e.IsCurrent)
                .HasColumnName("is_current");

            entity.Property(e => e.UserId)
                .HasColumnName("user_id");

            entity.Property(e => e.SubscriptionPlanId)
                .HasColumnName("subscription_plan_id");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_subscriptions__user_id__B145AAB4");

            entity.HasOne(d => d.SubscriptionPlan)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(d => d.SubscriptionPlanId)
                .HasConstraintName("FK__user_subscriptions__subscription_plan_id__B2566202");

        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83F1AE63DDC");

            entity.ToTable("payments");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .HasColumnName("id");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");

            entity.Property(e => e.PayDate)
                //.HasColumnType("datetime")
                .HasColumnName("pay_date");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("transaction_id");

            entity.Property(e => e.UserId)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__payments__user_id__D4A041FD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
