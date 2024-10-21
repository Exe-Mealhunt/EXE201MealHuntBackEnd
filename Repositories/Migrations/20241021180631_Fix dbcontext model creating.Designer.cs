﻿// <auto-generated />
using System;
using MealHunt_Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealHunt_Repositories.Migrations
{
    [DbContext(typeof(MealHuntContext))]
    [Migration("20241021180631_Fix dbcontext model creating")]
    partial class Fixdbcontextmodelcreating
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealHunt_Repositories.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__categori__3213E83FD239E576");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer")
                        .HasColumnName("post_id");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<int?>("ReplyToId")
                        .HasColumnType("integer")
                        .HasColumnName("replyTo_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__comments__3213E83FEFE461DC");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("IngredientName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ingredient_name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__ingredie__3213E83F8E5F7920");

                    b.ToTable("ingredients", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.IngredientCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__ingredie__3213E83F52FA63E0");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IngredientId");

                    b.ToTable("ingredientCategories", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.IngredientShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int?>("ShoppingListsId")
                        .HasColumnType("integer")
                        .HasColumnName("shoppingLists_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__ingredie__3213E83F65AF0674");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ShoppingListsId");

                    b.ToTable("ingredientShoppingLists", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Occasion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__occasion__3213E83F7E4E508E");

                    b.ToTable("occasions", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("id");

                    b.Property<double>("Amount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pay_date");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("transaction_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__Payment__3213E83F1AE63DDC");

                    b.HasIndex("UserId");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("title");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__posts__3213E83F5095F241");

                    b.HasIndex("UserId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("content");

                    b.Property<int?>("CookingTime")
                        .HasColumnType("integer")
                        .HasColumnName("cooking_time");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("OccasionId")
                        .HasColumnType("integer")
                        .HasColumnName("occasion_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Tutorial")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("tutorial");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("Video")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("video");

                    b.HasKey("Id")
                        .HasName("PK__recipes__3213E83FDEC2D5E6");

                    b.HasIndex("OccasionId");

                    b.ToTable("recipes", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<double?>("Quantity")
                        .HasColumnType("double precision")
                        .HasColumnName("quantity");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer")
                        .HasColumnName("recipe_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Unit")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("unit");

                    b.HasKey("Id")
                        .HasName("PK__recipeIn__3213E83FCE3B5733");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipeIngredients", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.SavedRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer")
                        .HasColumnName("recipe_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__savedRec__3213E83F0007AF5A");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("savedRecipes", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer")
                        .HasColumnName("recipe_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__shopping__3213E83F19C5C534");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("shoppingLists", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.SubscriptionPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("currency");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<long>("DurationInDays")
                        .HasColumnType("bigint")
                        .HasColumnName("duration_in_days");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("PK__SubscriptionPlan__3213E83FFEEA542A");

                    b.ToTable("subscription_plans", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("role");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83F8682BC63");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.UserSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("boolean")
                        .HasColumnName("is_current");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int?>("SubscriptionPlanId")
                        .HasColumnType("integer")
                        .HasColumnName("subscription_plan_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__UserSubscription__3213E83FADFC563A");

                    b.HasIndex("SubscriptionPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("user_subscriptions", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Comment", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__comments__post_i__5812160E");

                    b.HasOne("MealHunt_Repositories.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__comments__user_i__59063A47");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.IngredientCategory", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Category", "Category")
                        .WithMany("IngredientCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__ingredien__categ__5070F446");

                    b.HasOne("MealHunt_Repositories.Entities.Ingredient", "Ingredient")
                        .WithMany("IngredientCategories")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK__ingredien__ingre__4F7CD00D");

                    b.Navigation("Category");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.IngredientShoppingList", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Ingredient", "Ingredient")
                        .WithMany("IngredientShoppingLists")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK__ingredien__ingre__534D60F1");

                    b.HasOne("MealHunt_Repositories.Entities.ShoppingList", "ShoppingLists")
                        .WithMany("IngredientShoppingLists")
                        .HasForeignKey("ShoppingListsId")
                        .HasConstraintName("FK__ingredien__shopp__5441852A");

                    b.Navigation("Ingredient");

                    b.Navigation("ShoppingLists");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Payment", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__payments__user_id__D4A041FD");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Post", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__posts__user_id__571DF1D5");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Recipe", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Occasion", "Occasion")
                        .WithMany("Recipes")
                        .HasForeignKey("OccasionId")
                        .HasConstraintName("FK__recipes__occasio__4E88ABD4");

                    b.Navigation("Occasion");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK__recipeIng__ingre__4CA06362");

                    b.HasOne("MealHunt_Repositories.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__recipeIng__recip__4D94879B");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.SavedRecipe", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Recipe", "Recipe")
                        .WithMany("SavedRecipes")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__savedReci__recip__5629CD9C");

                    b.HasOne("MealHunt_Repositories.Entities.User", "User")
                        .WithMany("SavedRecipes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__savedReci__user___5535A963");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.ShoppingList", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.Recipe", "Recipe")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__shoppingL__recip__52593CB8");

                    b.HasOne("MealHunt_Repositories.Entities.User", "User")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__shoppingL__user___5165187F");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.UserSubscription", b =>
                {
                    b.HasOne("MealHunt_Repositories.Entities.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("SubscriptionPlanId")
                        .HasConstraintName("FK__user_subscriptions__subscription_plan_id__B2566202");

                    b.HasOne("MealHunt_Repositories.Entities.User", "User")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__user_subscriptions__user_id__B145AAB4");

                    b.Navigation("SubscriptionPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Category", b =>
                {
                    b.Navigation("IngredientCategories");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Ingredient", b =>
                {
                    b.Navigation("IngredientCategories");

                    b.Navigation("IngredientShoppingLists");

                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Occasion", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("SavedRecipes");

                    b.Navigation("ShoppingLists");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.ShoppingList", b =>
                {
                    b.Navigation("IngredientShoppingLists");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.SubscriptionPlan", b =>
                {
                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("MealHunt_Repositories.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Payments");

                    b.Navigation("Posts");

                    b.Navigation("SavedRecipes");

                    b.Navigation("ShoppingLists");

                    b.Navigation("UserSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
