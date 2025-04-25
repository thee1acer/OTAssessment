using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedreferenceinWagers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wagers_BrandId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_CreatedDateTime",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_ExternalReferenceId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_TransactionTypeId",
                table: "Wagers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Wagers_BrandId",
                table: "Wagers",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_CreatedDateTime",
                table: "Wagers",
                column: "CreatedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_ExternalReferenceId",
                table: "Wagers",
                column: "ExternalReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_TransactionTypeId",
                table: "Wagers",
                column: "TransactionTypeId");
        }
    }
}
