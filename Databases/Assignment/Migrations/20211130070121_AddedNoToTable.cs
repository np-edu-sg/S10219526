using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class AddedNoToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotId",
                table: "ActivityBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySlots",
                table: "ActivitySlots");

            migrationBuilder.DropIndex(
                name: "IX_ActivitySlots_ActivityId",
                table: "ActivitySlots");

            migrationBuilder.DropIndex(
                name: "IX_ActivityBookings_ActivitySlotId",
                table: "ActivityBookings");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActivitySlots");

            migrationBuilder.RenameColumn(
                name: "IntervalSeconds",
                table: "Classes",
                newName: "IntervalMinutes");

            migrationBuilder.RenameColumn(
                name: "ActivitySlotId",
                table: "ActivityBookings",
                newName: "ActivitySlotActivityId");

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivitySlotDateTime",
                table: "ActivityBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySlots",
                table: "ActivitySlots",
                columns: new[] { "ActivityId", "DateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBookings_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings",
                columns: new[] { "ActivitySlotActivityId", "ActivitySlotDateTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings",
                columns: new[] { "ActivitySlotActivityId", "ActivitySlotDateTime" },
                principalTable: "ActivitySlots",
                principalColumns: new[] { "ActivityId", "DateTime" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySlots",
                table: "ActivitySlots");

            migrationBuilder.DropIndex(
                name: "IX_ActivityBookings_ActivitySlotActivityId_ActivitySlotDateTime",
                table: "ActivityBookings");

            migrationBuilder.DropColumn(
                name: "No",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "ActivitySlotDateTime",
                table: "ActivityBookings");

            migrationBuilder.RenameColumn(
                name: "IntervalMinutes",
                table: "Classes",
                newName: "IntervalSeconds");

            migrationBuilder.RenameColumn(
                name: "ActivitySlotActivityId",
                table: "ActivityBookings",
                newName: "ActivitySlotId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "DishOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActivitySlots",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySlots",
                table: "ActivitySlots",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySlots_ActivityId",
                table: "ActivitySlots",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBookings_ActivitySlotId",
                table: "ActivityBookings",
                column: "ActivitySlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBookings_ActivitySlots_ActivitySlotId",
                table: "ActivityBookings",
                column: "ActivitySlotId",
                principalTable: "ActivitySlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
