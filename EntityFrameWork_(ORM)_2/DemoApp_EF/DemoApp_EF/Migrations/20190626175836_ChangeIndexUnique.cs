using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp_EF.Migrations
{
    public partial class ChangeIndexUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UQ_Customers_Name",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name",
                schema: "dbo",
                table: "Customers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Name",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_Customers_Name",
                schema: "dbo",
                table: "Customers",
                column: "Name");
        }
    }
}
