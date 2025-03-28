using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddWords.Migrations
{
    /// <inheritdoc />
    public partial class TabelaWordsMudanca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordsId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_WordsId",
                table: "Translations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Translations_WordsId",
                table: "Translations",
                column: "WordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordsId",
                table: "Translations",
                column: "WordsId",
                principalTable: "Words",
                principalColumn: "IdWord",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
