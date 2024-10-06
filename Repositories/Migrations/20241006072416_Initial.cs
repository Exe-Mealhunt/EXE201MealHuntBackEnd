using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealHunt_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__3213E83FD239E576", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    unit = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    quantity = table.Column<double>(type: "double precision", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ingredie__3213E83F8E5F7920", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "occasions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__occasion__3213E83F7E4E508E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F8682BC63", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredientCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: true),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ingredie__3213E83F52FA63E0", x => x.id);
                    table.ForeignKey(
                        name: "FK__ingredien__categ__5070F446",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ingredien__ingre__4F7CD00D",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    occasion_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    tutorial = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recipes__3213E83FDEC2D5E6", x => x.id);
                    table.ForeignKey(
                        name: "FK__recipes__occasio__4E88ABD4",
                        column: x => x.occasion_id,
                        principalTable: "occasions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    content = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__posts__3213E83F5095F241", x => x.id);
                    table.ForeignKey(
                        name: "FK__posts__user_id__571DF1D5",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "recipeIngredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: true),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    unit = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    quantity = table.Column<double>(type: "double precision", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recipeIn__3213E83FCE3B5733", x => x.id);
                    table.ForeignKey(
                        name: "FK__recipeIng__ingre__4CA06362",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__recipeIng__recip__4D94879B",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "savedRecipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__savedRec__3213E83F0007AF5A", x => x.id);
                    table.ForeignKey(
                        name: "FK__savedReci__recip__5629CD9C",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__savedReci__user___5535A963",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "shoppingLists",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shopping__3213E83F19C5C534", x => x.id);
                    table.ForeignKey(
                        name: "FK__shoppingL__recip__52593CB8",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__shoppingL__user___5165187F",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    replyTo_id = table.Column<int>(type: "integer", nullable: true),
                    post_id = table.Column<int>(type: "integer", nullable: true),
                    content = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__comments__3213E83FEFE461DC", x => x.id);
                    table.ForeignKey(
                        name: "FK__comments__post_i__5812160E",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__comments__user_i__59063A47",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ingredientShoppingLists",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: true),
                    shoppingLists_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ingredie__3213E83F65AF0674", x => x.id);
                    table.ForeignKey(
                        name: "FK__ingredien__ingre__534D60F1",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ingredien__shopp__5441852A",
                        column: x => x.shoppingLists_id,
                        principalTable: "shoppingLists",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_post_id",
                table: "comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientCategories_category_id",
                table: "ingredientCategories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientCategories_ingredient_id",
                table: "ingredientCategories",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientShoppingLists_ingredient_id",
                table: "ingredientShoppingLists",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientShoppingLists_shoppingLists_id",
                table: "ingredientShoppingLists",
                column: "shoppingLists_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_user_id",
                table: "posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipeIngredients_ingredient_id",
                table: "recipeIngredients",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipeIngredients_recipe_id",
                table: "recipeIngredients",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_occasion_id",
                table: "recipes",
                column: "occasion_id");

            migrationBuilder.CreateIndex(
                name: "IX_savedRecipes_recipe_id",
                table: "savedRecipes",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_savedRecipes_user_id",
                table: "savedRecipes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingLists_recipe_id",
                table: "shoppingLists",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingLists_user_id",
                table: "shoppingLists",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "ingredientCategories");

            migrationBuilder.DropTable(
                name: "ingredientShoppingLists");

            migrationBuilder.DropTable(
                name: "recipeIngredients");

            migrationBuilder.DropTable(
                name: "savedRecipes");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "shoppingLists");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "occasions");
        }
    }
}
