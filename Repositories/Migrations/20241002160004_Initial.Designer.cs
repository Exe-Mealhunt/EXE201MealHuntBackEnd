﻿// <auto-generated />
using System;
using MealHunt_Repositories;
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
    [Migration("20241002160004_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealHunt_Repositories.Comment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("content");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer")
                        .HasColumnName("post_id");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<int?>("ReplyToId")
                        .HasColumnType("integer")
                        .HasColumnName("reply_to_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__comments__3213E83F3AFAC6D4");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<string>("IngredientName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ingredient_name");

                    b.Property<double?>("Quantity")
                        .HasColumnType("double precision")
                        .HasColumnName("quantity");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("type");

                    b.Property<string>("Unit")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("unit");

                    b.HasKey("Id")
                        .HasName("PK__ingredie__3213E83F3D655F03");

                    b.ToTable("ingredients", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.IngredientShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int?>("ShoppingListId")
                        .HasColumnType("integer")
                        .HasColumnName("shopping_list_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__ingredie__3213E83FF39B2E86");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ingredient_shopping_lists", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("content");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
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
                        .HasName("PK__posts__3213E83F32CDCF90");

                    b.HasIndex("UserId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("Video")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("video");

                    b.HasKey("Id")
                        .HasName("PK__recipes__3213E83F7E63A2BC");

                    b.ToTable("recipes", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
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
                        .HasName("PK__recipeIn__3213E83FD6FF7A34");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipe_ingredients", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.RecipeTag", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer")
                        .HasColumnName("recipe_id");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int?>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tags_id");

                    b.HasKey("Id")
                        .HasName("PK__recipeTa__3213E83F1E9E4B89");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TagId");

                    b.ToTable("recipe_tags", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.SavedRecipe", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
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
                        .HasName("PK__savedRec__3213E83F2EED4A92");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("saved_recipes", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
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
                        .HasName("PK__shopping__3213E83F1DF1A052");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("shopping_lists", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Tag", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__tags__3213E83FA6132A10");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Tip", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("content");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__tips__3213E83FA8BFE1CB");

                    b.ToTable("tips", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

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

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83FE45835CA");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MealHunt_Repositories.Comment", b =>
                {
                    b.HasOne("MealHunt_Repositories.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__comments__post_i__571DF1D5");

                    b.HasOne("MealHunt_Repositories.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__comments__user_i__5812160E");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.IngredientShoppingList", b =>
                {
                    b.HasOne("MealHunt_Repositories.Ingredient", "Ingredient")
                        .WithMany("IngredientShoppingLists")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK__ingredien__ingre__52593CB8");

                    b.HasOne("MealHunt_Repositories.ShoppingList", "ShoppingList")
                        .WithMany("IngredientShoppingLists")
                        .HasForeignKey("ShoppingListId")
                        .HasConstraintName("FK__ingredien__shopp__534D60F1");

                    b.Navigation("Ingredient");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("MealHunt_Repositories.Post", b =>
                {
                    b.HasOne("MealHunt_Repositories.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__posts__user_id__5629CD9C");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.RecipeIngredient", b =>
                {
                    b.HasOne("MealHunt_Repositories.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK__recipeIng__ingre__4CA06362");

                    b.HasOne("MealHunt_Repositories.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__recipeIng__recip__4D94879B");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MealHunt_Repositories.RecipeTag", b =>
                {
                    b.HasOne("MealHunt_Repositories.Recipe", "Recipe")
                        .WithMany("RecipeTags")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__recipeTag__recip__4E88ABD4");

                    b.HasOne("MealHunt_Repositories.Tag", "Tag")
                        .WithMany("RecipeTags")
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK__recipeTag__tags___4F7CD00D");

                    b.Navigation("Recipe");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MealHunt_Repositories.SavedRecipe", b =>
                {
                    b.HasOne("MealHunt_Repositories.Recipe", "Recipe")
                        .WithMany("SavedRecipes")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__savedReci__recip__5535A963");

                    b.HasOne("MealHunt_Repositories.User", "User")
                        .WithMany("SavedRecipes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__savedReci__user___5441852A");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.ShoppingList", b =>
                {
                    b.HasOne("MealHunt_Repositories.Recipe", "Recipe")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__shoppingL__recip__5165187F");

                    b.HasOne("MealHunt_Repositories.User", "User")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__shoppingL__user___5070F446");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealHunt_Repositories.Ingredient", b =>
                {
                    b.Navigation("IngredientShoppingLists");

                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("MealHunt_Repositories.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MealHunt_Repositories.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeTags");

                    b.Navigation("SavedRecipes");

                    b.Navigation("ShoppingLists");
                });

            modelBuilder.Entity("MealHunt_Repositories.ShoppingList", b =>
                {
                    b.Navigation("IngredientShoppingLists");
                });

            modelBuilder.Entity("MealHunt_Repositories.Tag", b =>
                {
                    b.Navigation("RecipeTags");
                });

            modelBuilder.Entity("MealHunt_Repositories.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");

                    b.Navigation("SavedRecipes");

                    b.Navigation("ShoppingLists");
                });
#pragma warning restore 612, 618
        }
    }
}
