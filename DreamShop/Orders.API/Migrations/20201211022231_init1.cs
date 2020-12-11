using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.API.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ConsigneeName = table.Column<string>(nullable: true),
                    Payment = table.Column<int>(nullable: false),
                    OriginalPriceSum = table.Column<decimal>(nullable: false),
                    NowPriceSum = table.Column<decimal>(nullable: false),
                    ShippingTime = table.Column<DateTime>(nullable: false),
                    PayTime = table.Column<DateTime>(nullable: false),
                    ReceiveTime = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrdersId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductNum = table.Column<int>(nullable: false),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    NowPrice = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    OrdersId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersInfo_Orders_OrdersId1",
                        column: x => x.OrdersId1,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersInfo_OrdersId1",
                table: "OrdersInfo",
                column: "OrdersId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersInfo");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
