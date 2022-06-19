using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppManager.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityModel",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityExecuteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ActivityID1 = table.Column<int>(type: "int", nullable: true),
                    ItemModelItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityModel", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_ActivityModel_ActivityModel_ActivityID1",
                        column: x => x.ActivityID1,
                        principalTable: "ActivityModel",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityModel_ItemModel_ItemModelItemID",
                        column: x => x.ItemModelItemID,
                        principalTable: "ItemModel",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityModel_ActivityID1",
                table: "ActivityModel",
                column: "ActivityID1");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityModel_ItemModelItemID",
                table: "ActivityModel",
                column: "ItemModelItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityModel");

            migrationBuilder.DropTable(
                name: "ItemModel");
        }
    }
}
