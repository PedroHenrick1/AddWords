using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddWords.Migrations
{
    /// <inheritdoc />
    public partial class Modification1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdWord",
                table: "Words",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTranslation",
                table: "Translations",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Words",
                newName: "IdWord");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Translations",
                newName: "IdTranslation");
        }
    }
}
