using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class UpdatedDishPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_DishOrders_DishId",
                table: "DishOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "DishOrders",
                newName: "DishDiningLocationId");

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "DishOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                columns: new[] { "Name", "DiningLocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_DishName_DishDiningLocationId",
                table: "DishOrders",
                columns: new[] { "DishName", "DishDiningLocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishName_DishDiningLocationId",
                table: "DishOrders",
                columns: new[] { "DishName", "DishDiningLocationId" },
                principalTable: "Dishes",
                principalColumns: new[] { "Name", "DiningLocationId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishName_DishDiningLocationId",
                table: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_DishOrders_DishName_DishDiningLocationId",
                table: "DishOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "DishOrders");

            migrationBuilder.RenameColumn(
                name: "DishDiningLocationId",
                table: "DishOrders",
                newName: "DishId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_DishId",
                table: "DishOrders",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
