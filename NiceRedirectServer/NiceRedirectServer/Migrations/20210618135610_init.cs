using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceRedirectServer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Redirect",
                columns: table => new
                {
                    Key = table.Column<string>(type: "text", nullable: false),
                    Target = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirect", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Redirect_Key",
                table: "Redirect",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redirect");
        }
    }
}
