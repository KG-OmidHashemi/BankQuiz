using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankQuiz.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardHoldersNumber",
                table: "Cards",
                newName: "HoldersName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoldersName",
                table: "Cards",
                newName: "CardHoldersNumber");
        }
    }
}
