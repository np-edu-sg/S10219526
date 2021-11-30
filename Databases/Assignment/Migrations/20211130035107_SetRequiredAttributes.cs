using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class SetRequiredAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotId",
                table: "ActivityBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySlots_Activities_ActivityId",
                table: "ActivitySlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassBookings_Classes_ClassId",
                table: "ClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassBookings_Passengers_PassengerId",
                table: "ClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DiningLocations_DiningLocationId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_CabinServices_CabinServiceId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Passengers_PassengerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_DiningLocations_DiningLocationId",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "DiningLocationId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "DishOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "DishOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CabinServiceId",
                table: "DishOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiningLocationId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DiningLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Venue",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "ClassBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ActivitySlots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivitySlotId",
                table: "ActivityBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Venue",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotId",
                table: "ActivityBookings",
                column: "ActivitySlotId",
                principalTable: "ActivitySlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySlots_Activities_ActivityId",
                table: "ActivitySlots",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBookings_Classes_ClassId",
                table: "ClassBookings",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBookings_Passengers_PassengerId",
                table: "ClassBookings",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DiningLocations_DiningLocationId",
                table: "Dishes",
                column: "DiningLocationId",
                principalTable: "DiningLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_CabinServices_CabinServiceId",
                table: "DishOrders",
                column: "CabinServiceId",
                principalTable: "CabinServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Passengers_PassengerId",
                table: "Reservations",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_DiningLocations_DiningLocationId",
                table: "Tables",
                column: "DiningLocationId",
                principalTable: "DiningLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotId",
                table: "ActivityBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySlots_Activities_ActivityId",
                table: "ActivitySlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassBookings_Classes_ClassId",
                table: "ClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassBookings_Passengers_PassengerId",
                table: "ClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DiningLocations_DiningLocationId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_CabinServices_CabinServiceId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Passengers_PassengerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_DiningLocations_DiningLocationId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DiningLocations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "DiningLocationId",
                table: "Tables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DishOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "DishOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CabinServiceId",
                table: "DishOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DiningLocationId",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Venue",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "ClassBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ActivitySlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActivitySlotId",
                table: "ActivityBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Venue",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotId",
                table: "ActivityBookings",
                column: "ActivitySlotId",
                principalTable: "ActivitySlots",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySlots_Activities_ActivityId",
                table: "ActivitySlots",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBookings_Classes_ClassId",
                table: "ClassBookings",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBookings_Passengers_PassengerId",
                table: "ClassBookings",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DiningLocations_DiningLocationId",
                table: "Dishes",
                column: "DiningLocationId",
                principalTable: "DiningLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_CabinServices_CabinServiceId",
                table: "DishOrders",
                column: "CabinServiceId",
                principalTable: "CabinServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Passengers_PassengerId",
                table: "Reservations",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_DiningLocations_DiningLocationId",
                table: "Tables",
                column: "DiningLocationId",
                principalTable: "DiningLocations",
                principalColumn: "Id");
        }
    }
}
