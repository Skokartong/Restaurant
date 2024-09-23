using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class logIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameOfDish",
                table: "Menus",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Drink",
                table: "Menus",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingEnd", "BookingStart", "Message" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 10, 31, 837, DateTimeKind.Local).AddTicks(969), new DateTime(2024, 9, 23, 17, 10, 31, 837, DateTimeKind.Local).AddTicks(824), "Food better be good..." });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingEnd", "BookingStart", "Message" },
                values: new object[] { new DateTime(2024, 9, 24, 18, 10, 31, 837, DateTimeKind.Local).AddTicks(977), new DateTime(2024, 9, 24, 16, 10, 31, 837, DateTimeKind.Local).AddTicks(973), "One of us needs gluten free options in menu!" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdditionalInformation",
                value: "Authentic italian food. No ketchup!");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdditionalInformation",
                value: "Vegetarian sushi is available");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdditionalInformation",
                value: "More is less here!");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "NameOfDish",
                table: "Menus",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Drink",
                table: "Menus",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingEnd", "BookingStart", "Message" },
                values: new object[] { new DateTime(2024, 9, 19, 22, 15, 32, 717, DateTimeKind.Local).AddTicks(7774), new DateTime(2024, 9, 19, 20, 15, 32, 717, DateTimeKind.Local).AddTicks(7716), null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingEnd", "BookingStart", "Message" },
                values: new object[] { new DateTime(2024, 9, 20, 21, 15, 32, 717, DateTimeKind.Local).AddTicks(7780), new DateTime(2024, 9, 20, 19, 15, 32, 717, DateTimeKind.Local).AddTicks(7777), null });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdditionalInformation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdditionalInformation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdditionalInformation",
                value: null);
        }
    }
}
