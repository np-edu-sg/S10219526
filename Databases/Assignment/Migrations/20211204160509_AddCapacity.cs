using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class AddCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationSeconds",
                table: "Activity",
                newName: "DurationMinutes");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "ActivitySlot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ActivitySlot");

            migrationBuilder.RenameColumn(
                name: "DurationMinutes",
                table: "Activity",
                newName: "DurationSeconds");
        }
    }
}
