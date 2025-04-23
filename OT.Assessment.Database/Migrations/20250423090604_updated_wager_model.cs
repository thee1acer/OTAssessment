using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class updated_wager_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wagers_Countries_CountryId",
                table: "Wagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Wagers_Games_GameId",
                table: "Wagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Wagers_Providers_ProviderId",
                table: "Wagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Wagers_Themes_ThemeId",
                table: "Wagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Wagers_Transactions_TransactionId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_CountryId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_GameId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_ThemeId",
                table: "Wagers");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Wagers",
                newName: "TransactionTypeId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Wagers",
                newName: "ExternalReferenceId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Wagers",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Wagers",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Wagers_ProviderId",
                table: "Wagers",
                newName: "IX_Wagers_ExternalReferenceId");

            migrationBuilder.AlterColumn<string>(
                name: "SessionData",
                table: "Wagers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Wagers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Wagers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Wagers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Wagers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBets",
                table: "Wagers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "Wagers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Wagers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Wagers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Wagers_TransactionId_ExternalReferenceId",
                table: "Wagers",
                columns: new[] { "TransactionId", "ExternalReferenceId" });

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_CreatedDateTime",
                table: "Wagers",
                column: "CreatedDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Wagers_TransactionId_ExternalReferenceId",
                table: "Wagers");

            migrationBuilder.DropIndex(
                name: "IX_Wagers_CreatedDateTime",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "NumberOfBets",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Wagers");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "Wagers",
                newName: "ThemeId");

            migrationBuilder.RenameColumn(
                name: "ExternalReferenceId",
                table: "Wagers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Wagers",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Wagers",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Wagers_ExternalReferenceId",
                table: "Wagers",
                newName: "IX_Wagers_ProviderId");

            migrationBuilder.AlterColumn<string>(
                name: "SessionData",
                table: "Wagers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_CountryId",
                table: "Wagers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_GameId",
                table: "Wagers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_ThemeId",
                table: "Wagers",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wagers_Countries_CountryId",
                table: "Wagers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wagers_Games_GameId",
                table: "Wagers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wagers_Providers_ProviderId",
                table: "Wagers",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wagers_Themes_ThemeId",
                table: "Wagers",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wagers_Transactions_TransactionId",
                table: "Wagers",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
