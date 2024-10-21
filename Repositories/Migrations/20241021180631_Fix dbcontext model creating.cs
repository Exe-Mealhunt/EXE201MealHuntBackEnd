using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealHunt_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Fixdbcontextmodelcreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_subscriptions_subscription_plans_SubscriptionPlanId1",
                table: "user_subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_user_subscriptions_SubscriptionPlanId1",
                table: "user_subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionPlanId1",
                table: "user_subscriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionPlanId1",
                table: "user_subscriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_subscriptions_SubscriptionPlanId1",
                table: "user_subscriptions",
                column: "SubscriptionPlanId1");

            migrationBuilder.AddForeignKey(
                name: "FK_user_subscriptions_subscription_plans_SubscriptionPlanId1",
                table: "user_subscriptions",
                column: "SubscriptionPlanId1",
                principalTable: "subscription_plans",
                principalColumn: "id");
        }
    }
}
