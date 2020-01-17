using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class addcustomerd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerDate",
                table: "CustomerBooking",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerDate",
                table: "CustomerBooking");
        }
    }
}
