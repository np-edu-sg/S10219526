using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBookings_Passengers_PassengerId",
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
                name: "FK_DishOrders_Dishes_DishName_DishDiningLocationId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Passengers_PassengerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableNo_DiningLocationId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_DiningLocations_DiningLocationId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiningLocations",
                table: "DiningLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassBookings",
                table: "ClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CabinServices",
                table: "CabinServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySlots",
                table: "ActivitySlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityBookings",
                table: "ActivityBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Table");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Passenger");

            migrationBuilder.RenameTable(
                name: "DishOrders",
                newName: "DishOrder");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.RenameTable(
                name: "DiningLocations",
                newName: "DiningLocation");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.RenameTable(
                name: "ClassBookings",
                newName: "ClassBooking");

            migrationBuilder.RenameTable(
                name: "CabinServices",
                newName: "CabinService");

            migrationBuilder.RenameTable(
                name: "ActivitySlots",
                newName: "ActivitySlot");

            migrationBuilder.RenameTable(
                name: "ActivityBookings",
                newName: "ActivityBooking");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_DiningLocationId",
                table: "Table",
                newName: "IX_Table_DiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TableNo_DiningLocationId",
                table: "Reservation",
                newName: "IX_Reservation_TableNo_DiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PassengerId",
                table: "Reservation",
                newName: "IX_Reservation_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrders_DishName_DishDiningLocationId",
                table: "DishOrder",
                newName: "IX_DishOrder_DishName_DishDiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrders_CabinServiceId",
                table: "DishOrder",
                newName: "IX_DishOrder_CabinServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_DiningLocationId",
                table: "Dish",
                newName: "IX_Dish_DiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassBookings_PassengerId",
                table: "ClassBooking",
                newName: "IX_ClassBooking_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassBookings_ClassId",
                table: "ClassBooking",
                newName: "IX_ClassBooking_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityBookings_PassengerId",
                table: "ActivityBooking",
                newName: "IX_ActivityBooking_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityBookings_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBooking",
                newName: "IX_ActivityBooking_ActivitySlotActivityId_ActivitySlotDateTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                columns: new[] { "No", "DiningLocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                columns: new[] { "Name", "DiningLocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiningLocation",
                table: "DiningLocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassBooking",
                table: "ClassBooking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CabinService",
                table: "CabinService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySlot",
                table: "ActivitySlot",
                columns: new[] { "ActivityId", "DateTime" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityBooking",
                table: "ActivityBooking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBooking_ActivitySlot_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBooking",
                columns: new[] { "ActivitySlotActivityId", "ActivitySlotDateTime" },
                principalTable: "ActivitySlot",
                principalColumns: new[] { "ActivityId", "DateTime" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBooking_Passenger_PassengerId",
                table: "ActivityBooking",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySlot_Activity_ActivityId",
                table: "ActivitySlot",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBooking_Class_ClassId",
                table: "ClassBooking",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBooking_Passenger_PassengerId",
                table: "ClassBooking",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_DiningLocation_DiningLocationId",
                table: "Dish",
                column: "DiningLocationId",
                principalTable: "DiningLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_CabinService_CabinServiceId",
                table: "DishOrder",
                column: "CabinServiceId",
                principalTable: "CabinService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dish_DishName_DishDiningLocationId",
                table: "DishOrder",
                columns: new[] { "DishName", "DishDiningLocationId" },
                principalTable: "Dish",
                principalColumns: new[] { "Name", "DiningLocationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Passenger_PassengerId",
                table: "Reservation",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Table_TableNo_DiningLocationId",
                table: "Reservation",
                columns: new[] { "TableNo", "DiningLocationId" },
                principalTable: "Table",
                principalColumns: new[] { "No", "DiningLocationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_DiningLocation_DiningLocationId",
                table: "Table",
                column: "DiningLocationId",
                principalTable: "DiningLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBooking_ActivitySlot_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBooking_Passenger_PassengerId",
                table: "ActivityBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySlot_Activity_ActivityId",
                table: "ActivitySlot");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassBooking_Class_ClassId",
                table: "ClassBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassBooking_Passenger_PassengerId",
                table: "ClassBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_DiningLocation_DiningLocationId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_CabinService_CabinServiceId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dish_DishName_DishDiningLocationId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Passenger_PassengerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Table_TableNo_DiningLocationId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_DiningLocation_DiningLocationId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiningLocation",
                table: "DiningLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassBooking",
                table: "ClassBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CabinService",
                table: "CabinService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySlot",
                table: "ActivitySlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityBooking",
                table: "ActivityBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "Tables");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Passenger",
                newName: "Passengers");

            migrationBuilder.RenameTable(
                name: "DishOrder",
                newName: "DishOrders");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.RenameTable(
                name: "DiningLocation",
                newName: "DiningLocations");

            migrationBuilder.RenameTable(
                name: "ClassBooking",
                newName: "ClassBookings");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "CabinService",
                newName: "CabinServices");

            migrationBuilder.RenameTable(
                name: "ActivitySlot",
                newName: "ActivitySlots");

            migrationBuilder.RenameTable(
                name: "ActivityBooking",
                newName: "ActivityBookings");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_Table_DiningLocationId",
                table: "Tables",
                newName: "IX_Tables_DiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_TableNo_DiningLocationId",
                table: "Reservations",
                newName: "IX_Reservations_TableNo_DiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PassengerId",
                table: "Reservations",
                newName: "IX_Reservations_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_DishName_DishDiningLocationId",
                table: "DishOrders",
                newName: "IX_DishOrders_DishName_DishDiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_CabinServiceId",
                table: "DishOrders",
                newName: "IX_DishOrders_CabinServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_DiningLocationId",
                table: "Dishes",
                newName: "IX_Dishes_DiningLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassBooking_PassengerId",
                table: "ClassBookings",
                newName: "IX_ClassBookings_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassBooking_ClassId",
                table: "ClassBookings",
                newName: "IX_ClassBookings_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityBooking_PassengerId",
                table: "ActivityBookings",
                newName: "IX_ActivityBookings_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityBooking_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings",
                newName: "IX_ActivityBookings_ActivitySlotActivityId_ActivitySlotDateTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                columns: new[] { "No", "DiningLocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                columns: new[] { "Name", "DiningLocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiningLocations",
                table: "DiningLocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassBookings",
                table: "ClassBookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CabinServices",
                table: "CabinServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySlots",
                table: "ActivitySlots",
                columns: new[] { "ActivityId", "DateTime" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityBookings",
                table: "ActivityBookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings",
                columns: new[] { "ActivitySlotActivityId", "ActivitySlotDateTime" },
                principalTable: "ActivitySlots",
                principalColumns: new[] { "ActivityId", "DateTime" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBookings_Passengers_PassengerId",
                table: "ActivityBookings",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");

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
                name: "FK_DishOrders_Dishes_DishName_DishDiningLocationId",
                table: "DishOrders",
                columns: new[] { "DishName", "DishDiningLocationId" },
                principalTable: "Dishes",
                principalColumns: new[] { "Name", "DiningLocationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Passengers_PassengerId",
                table: "Reservations",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableNo_DiningLocationId",
                table: "Reservations",
                columns: new[] { "TableNo", "DiningLocationId" },
                principalTable: "Tables",
                principalColumns: new[] { "No", "DiningLocationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_DiningLocations_DiningLocationId",
                table: "Tables",
                column: "DiningLocationId",
                principalTable: "DiningLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
