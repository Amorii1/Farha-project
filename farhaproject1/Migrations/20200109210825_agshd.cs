using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class agshd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DanceTeam",
                table: "TReservation");

            migrationBuilder.DropColumn(
                name: "Decoration",
                table: "TReservation");

            migrationBuilder.DropColumn(
                name: "HallName",
                table: "TReservation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerBooking");

            migrationBuilder.AddColumn<int>(
                name: "DanceTeamId",
                table: "TReservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DecorationId",
                table: "TReservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "TReservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DanceTeamId",
                table: "CustomerBooking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TReservation_DanceTeamId",
                table: "TReservation",
                column: "DanceTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TReservation_DecorationId",
                table: "TReservation",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_TReservation_HallId",
                table: "TReservation",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooking_DanceTeamId",
                table: "CustomerBooking",
                column: "DanceTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBooking_DanceTeam_DanceTeamId",
                table: "CustomerBooking",
                column: "DanceTeamId",
                principalTable: "DanceTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TReservation_DanceTeam_DanceTeamId",
                table: "TReservation",
                column: "DanceTeamId",
                principalTable: "DanceTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TReservation_Decoration_DecorationId",
                table: "TReservation",
                column: "DecorationId",
                principalTable: "Decoration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TReservation_HallInformation_HallId",
                table: "TReservation",
                column: "HallId",
                principalTable: "HallInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBooking_DanceTeam_DanceTeamId",
                table: "CustomerBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_TReservation_DanceTeam_DanceTeamId",
                table: "TReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_TReservation_Decoration_DecorationId",
                table: "TReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_TReservation_HallInformation_HallId",
                table: "TReservation");

            migrationBuilder.DropIndex(
                name: "IX_TReservation_DanceTeamId",
                table: "TReservation");

            migrationBuilder.DropIndex(
                name: "IX_TReservation_DecorationId",
                table: "TReservation");

            migrationBuilder.DropIndex(
                name: "IX_TReservation_HallId",
                table: "TReservation");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBooking_DanceTeamId",
                table: "CustomerBooking");

            migrationBuilder.DropColumn(
                name: "DanceTeamId",
                table: "TReservation");

            migrationBuilder.DropColumn(
                name: "DecorationId",
                table: "TReservation");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "TReservation");

            migrationBuilder.DropColumn(
                name: "DanceTeamId",
                table: "CustomerBooking");

            migrationBuilder.AddColumn<string>(
                name: "DanceTeam",
                table: "TReservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Decoration",
                table: "TReservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HallName",
                table: "TReservation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerBooking",
                nullable: true);
        }
    }
}
