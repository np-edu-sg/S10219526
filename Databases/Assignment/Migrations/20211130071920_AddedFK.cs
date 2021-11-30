using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class AddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tables");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Reservations",
                newName: "TableNo");

            migrationBuilder.AddColumn<int>(
                name: "DiningLocationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                columns: new[] { "No", "DiningLocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableNo_DiningLocationId",
                table: "Reservations",
                columns: new[] { "TableNo", "DiningLocationId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableNo_DiningLocationId",
                table: "Reservations",
                columns: new[] { "TableNo", "DiningLocationId" },
                principalTable: "Tables",
                principalColumns: new[] { "No", "DiningLocationId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableNo_DiningLocationId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableNo_DiningLocationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DiningLocationId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TableNo",
                table: "Reservations",
                newName: "TableId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
