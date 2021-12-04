using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class UpdateClassIntervalAndDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntervalMinutes",
                table: "Class",
                newName: "IntervalDays");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Dish");

            migrationBuilder.RenameColumn(
                name: "IntervalDays",
                table: "Class",
                newName: "IntervalMinutes");
        }
    }
}
