using Microsoft.EntityFrameworkCore.Migrations;

namespace VClassroom.Authentication.Api.Data.Migrations
{
    public partial class add_auto_increment_to_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "uId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uId",
                table: "AspNetUsers");
        }
    }
}
