using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.API.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Sserial",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sserial",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
