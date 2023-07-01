using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectPRN_FAP.DataAccess.Data
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roles (RoleName) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO Roles (RoleName) VALUES ('Teacher')");
            migrationBuilder.Sql("INSERT INTO Roles (RoleName) VALUES ('Student')");
            migrationBuilder.Sql("INSERT INTO Semesters (SemesterName,StartDate,EndDate) VALUES ('SP22','2023-06-30','2023-06-30')");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
