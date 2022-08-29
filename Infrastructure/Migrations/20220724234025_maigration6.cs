using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class maigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderH",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Add_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_Discripton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Cust_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderH", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderH_Customers_Cust_Id",
                        column: x => x.Cust_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderD",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrederH_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Item_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderD_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderD_OrderH_OrederH_Id",
                        column: x => x.OrederH_Id,
                        principalTable: "OrderH",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderD_Item_Id",
                table: "OrderD",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderD_OrederH_Id",
                table: "OrderD",
                column: "OrederH_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderH_Cust_Id",
                table: "OrderH",
                column: "Cust_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderD");

            migrationBuilder.DropTable(
                name: "OrderH");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Add_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cust_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Item_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_Cust_Id",
                        column: x => x.Cust_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Cust_Id",
                table: "Orders",
                column: "Cust_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Item_Id",
                table: "Orders",
                column: "Item_Id");
        }
    }
}
