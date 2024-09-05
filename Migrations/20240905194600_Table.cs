using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Tables");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsAvailable",
                value: false);
        }
    }
}
