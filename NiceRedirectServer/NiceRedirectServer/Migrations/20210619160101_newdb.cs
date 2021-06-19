using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceRedirectServer.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Redirect",
                columns: table => new
                {
                    Key = table.Column<string>(type: "text", nullable: false),
                    RedirectData_Target = table.Column<string>(type: "text", nullable: true),
                    RedirectData_Type = table.Column<byte>(type: "smallint", nullable: true),
                    RedirectData_Password = table.Column<string>(type: "text", nullable: true)
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
