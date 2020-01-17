using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class ssddddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CutomerSelect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DanceTeamId = table.Column<int>(nullable: false),
                    DecorationId = table.Column<int>(nullable: false),
                    HallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CutomerSelect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CutomerSelect_DanceTeam_DanceTeamId",
                        column: x => x.DanceTeamId,
                        principalTable: "DanceTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CutomerSelect_Decoration_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decoration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CutomerSelect_HallInformation_HallId",
                        column: x => x.HallId,
                        principalTable: "HallInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CutomerSelect_DanceTeamId",
                table: "CutomerSelect",
                column: "DanceTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CutomerSelect_DecorationId",
                table: "CutomerSelect",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_CutomerSelect_HallId",
                table: "CutomerSelect",
                column: "HallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CutomerSelect");
        }
    }
}
