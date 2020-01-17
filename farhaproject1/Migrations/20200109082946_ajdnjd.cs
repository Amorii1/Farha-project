using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class ajdnjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoOfDecoration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImgFile = table.Column<string>(nullable: true),
                    DecorationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoOfDecoration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoOfDecoration_Decoration_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decoration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoOfDecoration_DecorationId",
                table: "PhotoOfDecoration",
                column: "DecorationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoOfDecoration");
        }
    }
}
