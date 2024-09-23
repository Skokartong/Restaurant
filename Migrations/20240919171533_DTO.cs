using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class DTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FK_TableId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "One way street 1");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Two way street 2");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "Three way street 3");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ingredients",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ingredients",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ingredients",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "FK_TableId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 6, 0, 45, 59, 852, DateTimeKind.Local).AddTicks(1885), new DateTime(2024, 9, 5, 22, 45, 59, 852, DateTimeKind.Local).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 6, 23, 45, 59, 852, DateTimeKind.Local).AddTicks(1894), new DateTime(2024, 9, 6, 21, 45, 59, 852, DateTimeKind.Local).AddTicks(1890) });
        }
    }
}
