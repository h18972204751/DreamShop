using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.API.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    LoginPassword = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LoginsId = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    CardId = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Integral = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    UserLevel = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Logins_LoginsId",
                        column: x => x.LoginsId,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UsersId = table.Column<string>(nullable: true),
                    RolesId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RolesId",
                table: "UserRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersId",
                table: "UserRoles",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginsId",
                table: "Users",
                column: "LoginsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
