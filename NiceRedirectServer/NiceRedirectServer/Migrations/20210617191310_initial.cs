using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceRedirectServer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Redirects",
                columns: table => new
                {
                    Key = table.Column<string>(type: "text", nullable: false),
                    Target = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirects", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Redirects_Key",
                table: "Redirects",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redirects");
        }
    }
}
