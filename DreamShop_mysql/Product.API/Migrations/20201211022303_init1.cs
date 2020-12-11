using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.API.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Core = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    SellNum = table.Column<int>(nullable: false),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    NowPrice = table.Column<decimal>(nullable: false),
                    SellTime = table.Column<DateTime>(nullable: false),
                    Online = table.Column<bool>(nullable: false),
                    IsTop = table.Column<bool>(nullable: false),
                    TopTime = table.Column<DateTime>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    SetNewDays = table.Column<short>(nullable: false),
                    IsCheck = table.Column<short>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    SellLimit = table.Column<string>(nullable: true),
                    Descript = table.Column<string>(nullable: true),
                    PublishStatus = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PropertiesGuid = table.Column<string>(nullable: true),
                    ProductID = table.Column<string>(nullable: true),
                    ProductsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductsId",
                table: "ProductProperties",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
