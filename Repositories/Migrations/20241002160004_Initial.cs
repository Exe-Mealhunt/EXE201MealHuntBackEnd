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
                name: "recipe_ingredients",
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
                name: "recipe_tags",
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
                name: "saved_recipes",
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
                name: "shopping_lists",
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
                    reply_to_id = table.Column<int>(type: "integer", nullable: true),
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
                name: "ingredient_shopping_lists",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: true),
                    shopping_list_id = table.Column<int>(type: "integer", nullable: true),
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
                        column: x => x.shopping_list_id,
                        principalTable: "shopping_lists",
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
                name: "IX_ingredient_shopping_lists_ingredient_id",
                table: "ingredient_shopping_lists",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_shopping_lists_shopping_list_id",
                table: "ingredient_shopping_lists",
                column: "shopping_list_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_user_id",
                table: "posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredients_ingredient_id",
                table: "recipe_ingredients",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredients_recipe_id",
                table: "recipe_ingredients",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_tags_recipe_id",
                table: "recipe_tags",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_tags_tags_id",
                table: "recipe_tags",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "IX_saved_recipes_recipe_id",
                table: "saved_recipes",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_saved_recipes_user_id",
                table: "saved_recipes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_lists_recipe_id",
                table: "shopping_lists",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_lists_user_id",
                table: "shopping_lists",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "ingredient_shopping_lists");

            migrationBuilder.DropTable(
                name: "recipe_ingredients");

            migrationBuilder.DropTable(
                name: "recipe_tags");

            migrationBuilder.DropTable(
                name: "saved_recipes");

            migrationBuilder.DropTable(
                name: "tips");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "shopping_lists");

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
