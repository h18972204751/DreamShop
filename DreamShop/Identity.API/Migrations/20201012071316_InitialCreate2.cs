using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.API.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserLogins_LoginsId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: "22737b5d-c652-492b-8e5f-445b48f13706");

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: "51a600da-2b79-421f-8adc-8a85ec7c2937");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "Logins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "LoginName", "LoginPassword", "Status", "UpdateTime", "UpdateUserId" },
                values: new object[] { "cd56076f-502b-4096-acb5-0c82d278b6ba", new DateTime(2020, 10, 12, 15, 13, 16, 412, DateTimeKind.Local).AddTicks(6209), null, "admin", "123", 0, new DateTime(2020, 10, 12, 15, 13, 16, 411, DateTimeKind.Local).AddTicks(2929), null });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "LoginName", "LoginPassword", "Status", "UpdateTime", "UpdateUserId" },
                values: new object[] { "b9089193-eb19-40f7-a023-20667ec9692e", new DateTime(2020, 10, 12, 15, 13, 16, 412, DateTimeKind.Local).AddTicks(6738), null, "wmh", "123456", 0, new DateTime(2020, 10, 12, 15, 13, 16, 412, DateTimeKind.Local).AddTicks(6688), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Logins_LoginsId",
                table: "Users",
                column: "LoginsId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Logins_LoginsId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.DeleteData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: "b9089193-eb19-40f7-a023-20667ec9692e");

            migrationBuilder.DeleteData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: "cd56076f-502b-4096-acb5-0c82d278b6ba");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "UserLogins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "LoginName", "LoginPassword", "Status", "UpdateTime", "UpdateUserId" },
                values: new object[] { "51a600da-2b79-421f-8adc-8a85ec7c2937", new DateTime(2020, 10, 12, 15, 12, 12, 863, DateTimeKind.Local).AddTicks(7591), null, "admin", "123", 0, new DateTime(2020, 10, 12, 15, 12, 12, 862, DateTimeKind.Local).AddTicks(3782), null });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "LoginName", "LoginPassword", "Status", "UpdateTime", "UpdateUserId" },
                values: new object[] { "22737b5d-c652-492b-8e5f-445b48f13706", new DateTime(2020, 10, 12, 15, 12, 12, 863, DateTimeKind.Local).AddTicks(8217), null, "wmh", "123456", 0, new DateTime(2020, 10, 12, 15, 12, 12, 863, DateTimeKind.Local).AddTicks(8163), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserLogins_LoginsId",
                table: "Users",
                column: "LoginsId",
                principalTable: "UserLogins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
