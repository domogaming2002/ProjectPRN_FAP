using Microsoft.EntityFrameworkCore.Migrations;

namespace PRN221_Project_RazorPage.DataAccess.Data
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roles (RoleName) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO Roles (RoleName) VALUES ('Teacher')");
            migrationBuilder.Sql("INSERT INTO Roles (RoleName) VALUES ('Student')");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
