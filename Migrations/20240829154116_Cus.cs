using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Cus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Restaurants_RestaurantId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Customers",
                newName: "FK_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RestaurantId",
                table: "Customers",
                newName: "IX_Customers_FK_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Restaurants_FK_RestaurantId",
                table: "Customers",
                column: "FK_RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Restaurants_FK_RestaurantId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "FK_RestaurantId",
                table: "Customers",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_FK_RestaurantId",
                table: "Customers",
                newName: "IX_Customers_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Restaurants_RestaurantId",
                table: "Customers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
