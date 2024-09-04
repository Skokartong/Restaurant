using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 41, 29, 623, DateTimeKind.Local).AddTicks(7153), new DateTime(2024, 9, 4, 20, 41, 29, 623, DateTimeKind.Local).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingEnd", "BookingStart" },
                values: new object[] { new DateTime(2024, 9, 5, 21, 41, 29, 623, DateTimeKind.Local).AddTicks(7160), new DateTime(2024, 9, 5, 19, 41, 29, 623, DateTimeKind.Local).AddTicks(7156) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

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
    }
}
