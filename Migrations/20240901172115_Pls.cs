using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Pls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FK_RestaurantId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "john@example.com", null, "John Doe", 123456790 },
                    { 2, "jane@example.com", null, "Jane Smith", 98743210 },
                    { 3, "alice@example.com", null, "Alice Johnson", 65654654 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "RestaurantName", "TypeOfRestaurant" },
                values: new object[,]
                {
                    { 1, "Italian Bistro", "Italian" },
                    { 2, "Sushi Palace", "Japanese" },
                    { 3, "Steak House", "American" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Drink", "FK_RestaurantId", "IsAvailable", "NameOfDish", "Price" },
                values: new object[,]
                {
                    { 1, "Wine", 1, true, "Spaghetti Carbonara", 12.99 },
                    { 2, "Sake", 2, true, "Sushi Combo", 15.99 },
                    { 3, "Beer", 3, true, "Grilled Steak", 20.989999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "AmountOfSeats", "FK_RestaurantId", "IsAvailable", "TableNumber" },
                values: new object[,]
                {
                    { 1, 4, 1, false, 1 },
                    { 2, 2, 1, false, 2 },
                    { 3, 6, 2, false, 3 },
                    { 4, 4, 3, false, 4 },
                    { 5, 8, 3, false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookingEnd", "BookingStart", "FK_CustomerId", "FK_RestaurantId", "FK_TableId", "NumberOfGuests" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 22, 21, 15, 40, DateTimeKind.Local).AddTicks(5236), new DateTime(2024, 9, 1, 20, 21, 15, 40, DateTimeKind.Local).AddTicks(5185), 1, 1, 1, 2 },
                    { 2, new DateTime(2024, 9, 2, 21, 21, 15, 40, DateTimeKind.Local).AddTicks(5244), new DateTime(2024, 9, 2, 19, 21, 15, 40, DateTimeKind.Local).AddTicks(5239), 2, 2, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
