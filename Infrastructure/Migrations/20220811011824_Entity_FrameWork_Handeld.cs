using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Entity_FrameWork_Handeld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderD_OrderH_OrederH_Id",
                table: "OrderD");

            migrationBuilder.RenameColumn(
                name: "OrederH_Id",
                table: "OrderD",
                newName: "Orderh_Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderD_OrederH_Id",
                table: "OrderD",
                newName: "IX_OrderD_Orderh_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderD_OrderH_Orderh_Id",
                table: "OrderD",
                column: "Orderh_Id",
                principalTable: "OrderH",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderD_OrderH_Orderh_Id",
                table: "OrderD");

            migrationBuilder.RenameColumn(
                name: "Orderh_Id",
                table: "OrderD",
                newName: "OrederH_Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderD_Orderh_Id",
                table: "OrderD",
                newName: "IX_OrderD_OrederH_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderD_OrderH_OrederH_Id",
                table: "OrderD",
                column: "OrederH_Id",
                principalTable: "OrderH",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
