using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDEVerse.Migrations
{
    public partial class _20200624_SeededRights2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Authorization",
                table: "Rights",
                keyColumn: "Id",
                keyValue: new Guid("eae48cab-2b37-4200-aef6-5870f6ec21c1"),
                column: "Title",
                value: "Доступ к расписанию");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Authorization",
                table: "Rights",
                keyColumn: "Id",
                keyValue: new Guid("eae48cab-2b37-4200-aef6-5870f6ec21c1"),
                column: "Title",
                value: "Доступ к панели управления");
        }
    }
}
