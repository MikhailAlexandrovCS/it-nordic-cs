using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM_HomeWork.Migrations
{
    public partial class InitialCreateAddUniqueConstraintInTableCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "UQ_City_Name",
                schema: "dbo",
                table: "City",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UQ_City_Name",
                schema: "dbo",
                table: "City");
        }
    }
}
