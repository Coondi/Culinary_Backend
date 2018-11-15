using Microsoft.EntityFrameworkCore.Migrations;

namespace Culinary.Repository.Migrations
{
    public partial class ChangesInTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Recipes_RecipeId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeRatings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Components",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Recipes_RecipeId",
                table: "Components",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Recipes_RecipeId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeRatings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Components",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Recipes_RecipeId",
                table: "Components",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
