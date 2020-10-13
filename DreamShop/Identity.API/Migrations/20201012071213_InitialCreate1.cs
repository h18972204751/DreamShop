using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.API.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "LoginName", "LoginPassword", "Status", "UpdateTime", "UpdateUserId" },
                values: new object[] { "51a600da-2b79-421f-8adc-8a85ec7c2937", new DateTime(2020, 10, 12, 15, 12, 12, 863, DateTimeKind.Local).AddTicks(7591), null, "admin", "123", 0, new DateTime(2020, 10, 12, 15, 12, 12, 862, DateTimeKind.Local).AddTicks(3782), null });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "LoginName", "LoginPassword", "Status", "UpdateTime", "UpdateUserId" },
                values: new object[] { "22737b5d-c652-492b-8e5f-445b48f13706", new DateTime(2020, 10, 12, 15, 12, 12, 863, DateTimeKind.Local).AddTicks(8217), null, "wmh", "123456", 0, new DateTime(2020, 10, 12, 15, 12, 12, 863, DateTimeKind.Local).AddTicks(8163), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: "22737b5d-c652-492b-8e5f-445b48f13706");

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: "51a600da-2b79-421f-8adc-8a85ec7c2937");
        }
    }
}
