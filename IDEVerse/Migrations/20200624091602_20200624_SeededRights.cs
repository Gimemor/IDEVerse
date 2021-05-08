using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDEVerse.Migrations
{
    public partial class _20200624_SeededRights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Authorization",
                table: "Rights",
                columns: new[] { "Id", "Description", "Mnemo", "Title" },
                values: new object[,]
                {
                    { new Guid("72f59bc4-47f8-4e7a-8fb5-7e1380cbe072"), "Доступ к панели управления", "right.IDEVerse/control-panel-access", "Доступ к панели управления" },
                    { new Guid("eae48cab-2b37-4200-aef6-5870f6ec21c1"), "Доступ к расписанию", "right.IDEVerse/schedule-access", "Доступ к панели управления" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Authorization",
                table: "Rights",
                keyColumn: "Id",
                keyValue: new Guid("72f59bc4-47f8-4e7a-8fb5-7e1380cbe072"));

            migrationBuilder.DeleteData(
                schema: "Authorization",
                table: "Rights",
                keyColumn: "Id",
                keyValue: new Guid("eae48cab-2b37-4200-aef6-5870f6ec21c1"));
        }
    }
}
