using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class H : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Restaurants_FK_RestaurantId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_FK_RestaurantId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Menus_FK_MenuId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customers_FK_CustomerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Orders_OrderId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Reservation_ReservationId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_OrderId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FK_RestaurantId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "FK_RestaurantId",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Tables",
                newName: "FK_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_ReservationId",
                table: "Tables",
                newName: "IX_Tables_FK_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_FK_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_FK_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "FK_MenuId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FK_CustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_TableId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfDish",
                table: "Menus",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "FK_RestaurantId",
                table: "Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Drink",
                table: "Menus",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FK_CustomerId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FK_TableId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_CustomerId",
                table: "Orders",
                column: "FK_CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_TableId",
                table: "Orders",
                column: "FK_TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RestaurantId",
                table: "Customers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FK_TableId",
                table: "Reservations",
                column: "FK_TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Restaurants_RestaurantId",
                table: "Customers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_FK_RestaurantId",
                table: "Menus",
                column: "FK_RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_FK_CustomerId",
                table: "Orders",
                column: "FK_CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_FK_MenuId",
                table: "Orders",
                column: "FK_MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_FK_TableId",
                table: "Orders",
                column: "FK_TableId",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_FK_CustomerId",
                table: "Reservations",
                column: "FK_CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_FK_TableId",
                table: "Reservations",
                column: "FK_TableId",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_FK_RestaurantId",
                table: "Tables",
                column: "FK_RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Restaurants_RestaurantId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_FK_RestaurantId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_FK_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Menus_FK_MenuId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_FK_TableId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_FK_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_FK_TableId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_FK_RestaurantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FK_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FK_TableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RestaurantId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_FK_TableId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FK_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FK_TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FK_TableId",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameColumn(
                name: "FK_RestaurantId",
                table: "Tables",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_FK_RestaurantId",
                table: "Tables",
                newName: "IX_Tables_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_FK_CustomerId",
                table: "Reservation",
                newName: "IX_Reservation_FK_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FK_MenuId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "FK_RestaurantId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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

            migrationBuilder.AddColumn<int>(
                name: "FK_RestaurantId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FK_CustomerId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_OrderId",
                table: "Tables",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FK_RestaurantId",
                table: "Customers",
                column: "FK_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Restaurants_FK_RestaurantId",
                table: "Customers",
                column: "FK_RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_FK_RestaurantId",
                table: "Menus",
                column: "FK_RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_FK_MenuId",
                table: "Orders",
                column: "FK_MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customers_FK_CustomerId",
                table: "Reservation",
                column: "FK_CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Orders_OrderId",
                table: "Tables",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Reservation_ReservationId",
                table: "Tables",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");
        }
    }
}
