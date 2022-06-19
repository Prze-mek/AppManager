using Microsoft.EntityFrameworkCore.Migrations;

namespace AppManager.Data.Migrations
{
    public partial class ChangeModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "ItemModel");

            migrationBuilder.AddColumn<int>(
                name: "ActivityModel",
                table: "ActivityModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityModel_ActivityModel",
                table: "ActivityModel",
                column: "ActivityModel");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityModel_ItemModel_ActivityModel",
                table: "ActivityModel",
                column: "ActivityModel",
                principalTable: "ItemModel",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityModel_ItemModel_ActivityModel",
                table: "ActivityModel");

            migrationBuilder.DropIndex(
                name: "IX_ActivityModel_ActivityModel",
                table: "ActivityModel");

            migrationBuilder.DropColumn(
                name: "ActivityModel",
                table: "ActivityModel");

            migrationBuilder.AddColumn<int>(
                name: "ActivityID",
                table: "ItemModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
