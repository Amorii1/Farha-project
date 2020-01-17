using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HallName",
                table: "TReservation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HallName",
                table: "TReservation");
        }
    }
}
