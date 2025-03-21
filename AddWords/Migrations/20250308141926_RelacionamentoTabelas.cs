﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddWords.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Words",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Words_userId",
                table: "Words",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Users_userId",
                table: "Words",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Users_userId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_userId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Words");
        }
    }
}
