using Microsoft.EntityFrameworkCore.Migrations;

namespace AppManager.Data.Migrations
{
    public partial class ChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityModel_ActivityModel_ActivityID1",
                table: "ActivityModel");

            migrationBuilder.DropIndex(
                name: "IX_ActivityModel_ActivityID1",
                table: "ActivityModel");

            migrationBuilder.DropColumn(
                name: "ActivityID1",
                table: "ActivityModel");

            migrationBuilder.AddColumn<int>(
                name: "ActivityID",
                table: "ItemModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "ItemModel");

            migrationBuilder.AddColumn<int>(
                name: "ActivityID1",
                table: "ActivityModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityModel_ActivityID1",
                table: "ActivityModel",
                column: "ActivityID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityModel_ActivityModel_ActivityID1",
                table: "ActivityModel",
                column: "ActivityID1",
                principalTable: "ActivityModel",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
