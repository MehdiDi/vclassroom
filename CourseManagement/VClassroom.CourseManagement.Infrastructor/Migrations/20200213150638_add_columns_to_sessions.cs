using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VClassroom.CourseManagement.Infrastructor.Migrations
{
    public partial class add_columns_to_sessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finish",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Sessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SessionStatus",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SessionStatus",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Finish",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
