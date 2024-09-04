using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class @string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FK_TableId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "123456790");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: "98743210");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Phone",
                value: "65654654");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 2, 56, 854, DateTimeKind.Local).AddTicks(8857), new DateTime(2024, 9, 4, 20, 2, 56, 854, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 5, 21, 2, 56, 854, DateTimeKind.Local).AddTicks(8863), new DateTime(2024, 9, 5, 19, 2, 56, 854, DateTimeKind.Local).AddTicks(8860) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FK_TableId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Customers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: 123456790);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: 98743210);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Phone",
                value: 65654654);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 1, 22, 21, 15, 40, DateTimeKind.Local).AddTicks(5236), new DateTime(2024, 9, 1, 20, 21, 15, 40, DateTimeKind.Local).AddTicks(5185) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 2, 21, 21, 15, 40, DateTimeKind.Local).AddTicks(5244), new DateTime(2024, 9, 2, 19, 21, 15, 40, DateTimeKind.Local).AddTicks(5239) });
        }
    }
}
