using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class Addedmissingfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Wagers_AccountId",
                table: "Wagers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_BrandId",
                table: "Wagers",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_TransactionTypeId",
                table: "Wagers",
                column: "TransactionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wagers_AccountId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_BrandId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_TransactionTypeId",
                table: "Wagers");
        }
    }
}
