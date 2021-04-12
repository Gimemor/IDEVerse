using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBCAcademy.Migrations
{
    public partial class Added_Attendace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleAttendance",
                schema: "Study",
                columns: table => new
                {
                    ScheduleEntryId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ScheduleEntryId1 = table.Column<Guid>(nullable: true),
                    UserId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAttendance", x => new { x.ScheduleEntryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ScheduleAttendance_Schedule_ScheduleEntryId",
                        column: x => x.ScheduleEntryId,
                        principalSchema: "Study",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleAttendance_Schedule_ScheduleEntryId1",
                        column: x => x.ScheduleEntryId1,
                        principalSchema: "Study",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleAttendance_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Authorization",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleAttendance_Users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Authorization",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAttendance_ScheduleEntryId1",
                schema: "Study",
                table: "ScheduleAttendance",
                column: "ScheduleEntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAttendance_UserId",
                schema: "Study",
                table: "ScheduleAttendance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAttendance_UserId1",
                schema: "Study",
                table: "ScheduleAttendance",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleAttendance",
                schema: "Study");
        }
    }
}
