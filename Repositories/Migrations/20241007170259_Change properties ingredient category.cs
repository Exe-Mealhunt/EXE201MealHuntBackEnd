using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealHunt_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Changepropertiesingredientcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "ingredientCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "ingredientCategories",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
