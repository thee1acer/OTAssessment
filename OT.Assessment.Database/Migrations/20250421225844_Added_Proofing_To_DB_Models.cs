using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class Added_Proofing_To_DB_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTypes_TransactionTypeName",
                table: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Themes_Name",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Games_Name",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeName",
                table: "TransactionTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeDescription",
                table: "TransactionTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AccountBalance",
                table: "Accounts",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "AccessDescription",
                table: "AccessLevels",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AccesType",
                table: "AccessLevels",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "AccesLevelId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Providers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ThemeId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TransactionTypes_Name",
                table: "TransactionTypes",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Themes_Name",
                table: "Themes",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Providers_Name",
                table: "Providers",
                column: "Name");

            migrationBuilder.UpdateData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("2077cfaa-7b5d-4d6f-85d7-c76e940f6971"),
                columns: new[] { "Description", "Type" },
                values: new object[] { "This is for qa-testers", "QaTester" });

            migrationBuilder.UpdateData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("9a3e8e9d-2b6d-4f6a-a5bb-5d4cd51c27ab"),
                columns: new[] { "Description", "Type" },
                values: new object[] { "This is for admin", "Administrator" });

            migrationBuilder.UpdateData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("e4c77b0d-b1ce-49d2-80f2-c52971b6b905"),
                columns: new[] { "Description", "Type" },
                values: new object[] { "This is for developers", "Developer" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccesLevelId",
                table: "Users",
                column: "AccesLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProviderId",
                table: "Games",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ThemeId",
                table: "Games",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Providers_ProviderId",
                table: "Games",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Themes_ThemeId",
                table: "Games",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccessLevels_AccesLevelId",
                table: "Users",
                column: "AccesLevelId",
                principalTable: "AccessLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Providers_ProviderId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Themes_ThemeId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccessLevels_AccesLevelId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccesLevelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccountId",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TransactionTypes_Name",
                table: "TransactionTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Themes_Name",
                table: "Themes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Providers_Name",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Games_ProviderId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ThemeId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AccesLevelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TransactionTypes",
                newName: "TransactionTypeName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TransactionTypes",
                newName: "TransactionTypeDescription");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "AccountBalance");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AccessLevels",
                newName: "AccessDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AccessLevels",
                newName: "AccesType");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_AccessLevels_AccessLevelId",
                        column: x => x.AccessLevelId,
                        principalTable: "AccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("2077cfaa-7b5d-4d6f-85d7-c76e940f6971"),
                columns: new[] { "AccesType", "AccessDescription" },
                values: new object[] { "QaTester", "This is for qa-testers" });

            migrationBuilder.UpdateData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("9a3e8e9d-2b6d-4f6a-a5bb-5d4cd51c27ab"),
                columns: new[] { "AccesType", "AccessDescription" },
                values: new object[] { "Administrator", "This is for admin" });

            migrationBuilder.UpdateData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("e4c77b0d-b1ce-49d2-80f2-c52971b6b905"),
                columns: new[] { "AccesType", "AccessDescription" },
                values: new object[] { "Developer", "This is for developers" });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_TransactionTypeName",
                table: "TransactionTypes",
                column: "TransactionTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Themes_Name",
                table: "Themes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_AccessLevelId",
                table: "ApplicationUsers",
                column: "AccessLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
