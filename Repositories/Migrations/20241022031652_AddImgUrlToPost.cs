using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealHunt_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddImgUrlToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_url",
                table: "posts",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_url",
                table: "posts");
        }
    }
}
