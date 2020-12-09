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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Core = table.Column<string>(nullable: true),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    NowPrice = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    LockStock = table.Column<int>(nullable: false),
                    SafeStock = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    ShelfLife = table.Column<int>(nullable: false),
                    Descript = table.Column<string>(nullable: true),
                    PublishStatus = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    AuditStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
