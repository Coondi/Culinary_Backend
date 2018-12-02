using Microsoft.EntityFrameworkCore.Migrations;

namespace Culinary.Repository.Migrations
{
    public partial class AddedPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Recipes");
        }
    }
}
