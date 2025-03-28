using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddWords.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentosConsertados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Translations",
                table: "Words");

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "Translations",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordsId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_WordsId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "Translations");

            migrationBuilder.AddColumn<List<string>>(
                name: "Translations",
                table: "Words",
                type: "text[]",
                nullable: false);
        }
    }
}
