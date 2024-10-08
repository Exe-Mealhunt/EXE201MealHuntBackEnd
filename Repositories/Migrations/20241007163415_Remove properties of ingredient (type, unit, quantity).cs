using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealHunt_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Removepropertiesofingredienttypeunitquantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "ingredients");

            migrationBuilder.DropColumn(
                name: "type",
                table: "ingredients");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "ingredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "quantity",
                table: "ingredients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "ingredients",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unit",
                table: "ingredients",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
