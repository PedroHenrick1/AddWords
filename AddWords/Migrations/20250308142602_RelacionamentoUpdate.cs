using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddWords.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Words");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Words",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
