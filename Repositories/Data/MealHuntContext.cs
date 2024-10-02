using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MealHunt_Repositories;

public partial class MealHuntContext : DbContext
{
    public MealHuntContext()
    {
    }

    public MealHuntContext(DbContextOptions<MealHuntContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientShoppingList> IngredientShoppingLists { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeTag> RecipeTags { get; set; }

    public virtual DbSet<SavedRecipe> SavedRecipes { get; set; }

    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456;Database=mealhuntdb;");

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
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3213E83F3AFAC6D4");

            entity.ToTable("comments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(1)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReplyToId).HasColumnName("reply_to_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__comments__post_i__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__comments__user_i__5812160E");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingredie__3213E83F3D655F03");

            entity.ToTable("ingredients");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(255)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<IngredientShoppingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingredie__3213E83FF39B2E86");

            entity.ToTable("ingredient_shopping_lists");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.ShoppingListId).HasColumnName("shopping_list_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientShoppingLists)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__ingredien__ingre__52593CB8");

            entity.HasOne(d => d.ShoppingList).WithMany(p => p.IngredientShoppingLists)
                .HasForeignKey(d => d.ShoppingListId)
                .HasConstraintName("FK__ingredien__shopp__534D60F1");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83F32CDCF90");

            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(1)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(1)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__posts__user_id__5629CD9C");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recipes__3213E83F7E63A2BC");

            entity.ToTable("recipes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Video)
                .HasMaxLength(255)
                .HasColumnName("video");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recipeIn__3213E83FD6FF7A34");

            entity.ToTable("recipe_ingredients");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
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

        modelBuilder.Entity<RecipeTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recipeTa__3213E83F1E9E4B89");

            entity.ToTable("recipe_tags");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TagId).HasColumnName("tags_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeTags)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__recipeTag__recip__4E88ABD4");

            entity.HasOne(d => d.Tag).WithMany(p => p.RecipeTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK__recipeTag__tags___4F7CD00D");
        });

        modelBuilder.Entity<SavedRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__savedRec__3213E83F2EED4A92");

            entity.ToTable("saved_recipes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.SavedRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__savedReci__recip__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.SavedRecipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__savedReci__user___5441852A");
        });

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shopping__3213E83F1DF1A052");

            entity.ToTable("shopping_lists");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__shoppingL__recip__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__shoppingL__user___5070F446");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tags__3213E83FA6132A10");

            entity.ToTable("tags");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tips__3213E83FA8BFE1CB");

            entity.ToTable("tips");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FE45835CA");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
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
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
