using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class addcustomerds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBooking_AspNetUsers_AdminApplicationId",
                table: "CustomerBooking");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBooking_AdminApplicationId",
                table: "CustomerBooking");

            migrationBuilder.DropColumn(
                name: "AdminApplicationId",
                table: "CustomerBooking");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "CustomerBooking",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooking_AdminId",
                table: "CustomerBooking",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBooking_AspNetUsers_AdminId",
                table: "CustomerBooking",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBooking_AspNetUsers_AdminId",
                table: "CustomerBooking");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBooking_AdminId",
                table: "CustomerBooking");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "CustomerBooking",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminApplicationId",
                table: "CustomerBooking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooking_AdminApplicationId",
                table: "CustomerBooking",
                column: "AdminApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBooking_AspNetUsers_AdminApplicationId",
                table: "CustomerBooking",
                column: "AdminApplicationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
