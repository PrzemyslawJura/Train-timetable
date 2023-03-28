using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_DOT_NET_APP.Data.Migrations
{
    public partial class addTimetableToDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book",
                table: "Timetable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book",
                table: "Timetable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
