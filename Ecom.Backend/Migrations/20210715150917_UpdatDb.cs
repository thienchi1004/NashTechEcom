using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.Backend.Migrations
{
    public partial class UpdatDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
