using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceRedirectServer.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RedirectData_Type",
                table: "Redirect",
                newName: "Data_Type");

            migrationBuilder.RenameColumn(
                name: "RedirectData_Target",
                table: "Redirect",
                newName: "Data_Target");

            migrationBuilder.RenameColumn(
                name: "RedirectData_Password",
                table: "Redirect",
                newName: "Data_Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data_Type",
                table: "Redirect",
                newName: "RedirectData_Type");

            migrationBuilder.RenameColumn(
                name: "Data_Target",
                table: "Redirect",
                newName: "RedirectData_Target");

            migrationBuilder.RenameColumn(
                name: "Data_Password",
                table: "Redirect",
                newName: "RedirectData_Password");
        }
    }
}
