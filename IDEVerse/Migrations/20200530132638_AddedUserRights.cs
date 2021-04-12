using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBCAcademy.Migrations
{
    public partial class AddedUserRights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rights",
                schema: "Authorization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Mnemo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RightToRole",
                schema: "Authorization",
                columns: table => new
                {
                    RightId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightToRole", x => new { x.RightId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RightToRole_Rights_RightId",
                        column: x => x.RightId,
                        principalSchema: "Authorization",
                        principalTable: "Rights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RightToRole_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Authorization",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RightToRole_RoleId",
                schema: "Authorization",
                table: "RightToRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RightToRole",
                schema: "Authorization");

            migrationBuilder.DropTable(
                name: "Rights",
                schema: "Authorization");
        }
    }
}
