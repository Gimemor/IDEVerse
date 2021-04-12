using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBCAcademy.Migrations
{
    public partial class PostgreInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Study");

            migrationBuilder.EnsureSchema(
                name: "Authorization");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Authorization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Mnemo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "Study",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Authorization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Authorization",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "Study",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Study",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "Study",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LessonDate = table.Column<DateTime>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Study",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Authorization",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectAssignments",
                schema: "Study",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAssignments", x => new { x.SubjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SubjectAssignments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Study",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Authorization",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskGrades",
                schema: "Study",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskGrades_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "Study",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskGrades_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Authorization",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "Authorization",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SubjectId",
                schema: "Study",
                table: "Schedule",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TeacherId",
                schema: "Study",
                table: "Schedule",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssignments_UserId",
                schema: "Study",
                table: "SubjectAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGrades_TaskId",
                schema: "Study",
                table: "TaskGrades",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGrades_UserId",
                schema: "Study",
                table: "TaskGrades",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SubjectId",
                schema: "Study",
                table: "Tasks",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "Study");

            migrationBuilder.DropTable(
                name: "SubjectAssignments",
                schema: "Study");

            migrationBuilder.DropTable(
                name: "TaskGrades",
                schema: "Study");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "Study");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Authorization");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "Study");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Authorization");
        }
    }
}
