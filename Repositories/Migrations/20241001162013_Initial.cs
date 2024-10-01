using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "ingredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    unit = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    quantity = table.Column<double>(type: "double precision", nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ingredie__3213E83F3D655F03", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recipes__3213E83F7E63A2BC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tags__3213E83FA6132A10", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tips",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tips__3213E83FA8BFE1CB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83FE45835CA", x => x.id);
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
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recipeIn__3213E83FD6FF7A34", x => x.id);
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
                name: "recipeTags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    tags_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recipeTa__3213E83F1E9E4B89", x => x.id);
                    table.ForeignKey(
                        name: "FK__recipeTag__recip__4E88ABD4",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__recipeTag__tags___4F7CD00D",
                        column: x => x.tags_id,
                        principalTable: "tags",
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
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__posts__3213E83F32CDCF90", x => x.id);
                    table.ForeignKey(
                        name: "FK__posts__user_id__5629CD9C",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "savedRecipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__savedRec__3213E83F2EED4A92", x => x.id);
                    table.ForeignKey(
                        name: "FK__savedReci__recip__5535A963",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__savedReci__user___5441852A",
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
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shopping__3213E83F1DF1A052", x => x.id);
                    table.ForeignKey(
                        name: "FK__shoppingL__recip__5165187F",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__shoppingL__user___5070F446",
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
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__comments__3213E83F3AFAC6D4", x => x.id);
                    table.ForeignKey(
                        name: "FK__comments__post_i__571DF1D5",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__comments__user_i__5812160E",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ingredientShoppingListss",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: true),
                    shoppingLists_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ingredie__3213E83FF39B2E86", x => x.id);
                    table.ForeignKey(
                        name: "FK__ingredien__ingre__52593CB8",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ingredien__shopp__534D60F1",
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
                name: "IX_ingredientShoppingListss_ingredient_id",
                table: "ingredientShoppingListss",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientShoppingListss_shoppingLists_id",
                table: "ingredientShoppingListss",
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
                name: "IX_recipeTags_recipe_id",
                table: "recipeTags",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipeTags_tags_id",
                table: "recipeTags",
                column: "tags_id");

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
                name: "ingredientShoppingListss");

            migrationBuilder.DropTable(
                name: "recipeIngredients");

            migrationBuilder.DropTable(
                name: "recipeTags");

            migrationBuilder.DropTable(
                name: "savedRecipes");

            migrationBuilder.DropTable(
                name: "tips");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "shoppingLists");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
