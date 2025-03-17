using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AddWords.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Users_userId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "Translation",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Words",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_userId",
                table: "Words",
                newName: "IX_Words_UserId");

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    IdTranslation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordsId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.IdTranslation);
                    table.ForeignKey(
                        name: "FK_Translations_Words_WordsId",
                        column: x => x.WordsId,
                        principalTable: "Words",
                        principalColumn: "IdWord",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_WordsId",
                table: "Translations",
                column: "WordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Users_UserId",
                table: "Words",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Users_UserId",
                table: "Words");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Words",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_UserId",
                table: "Words",
                newName: "IX_Words_userId");

            migrationBuilder.AddColumn<List<string>>(
                name: "Translation",
                table: "Words",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Users_userId",
                table: "Words",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
