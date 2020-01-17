using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace farhaproject1.Migrations
{
    public partial class addcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerBooking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    HallId = table.Column<int>(nullable: false),
                    DecorationId = table.Column<int>(nullable: false),
                    AdminId = table.Column<string>(nullable: true),
                    AdminApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBooking_AspNetUsers_AdminApplicationId",
                        column: x => x.AdminApplicationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerBooking_Decoration_DecorationId",
                        column: x => x.DecorationId,
                        principalTable: "Decoration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerBooking_HallInformation_HallId",
                        column: x => x.HallId,
                        principalTable: "HallInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooking_AdminApplicationId",
                table: "CustomerBooking",
                column: "AdminApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooking_DecorationId",
                table: "CustomerBooking",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooking_HallId",
                table: "CustomerBooking",
                column: "HallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBooking");
        }
    }
}
