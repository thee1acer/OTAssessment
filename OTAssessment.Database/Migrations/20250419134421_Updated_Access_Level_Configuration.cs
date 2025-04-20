using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Access_Level_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("0f2e9e4a-b535-4d6a-855a-a5d3d761eb8d"));

            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("1ad9aced-ba4b-4626-abb9-ccec1fd1beca"));

            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("7a4b1186-41bb-4079-99da-62a22b08c1a2"));

            migrationBuilder.InsertData(
                table: "AccessLevels",
                columns: new[] { "Id", "AccesType", "AccessDescription" },
                values: new object[,]
                {
                    { new Guid("2077cfaa-7b5d-4d6f-85d7-c76e940f6971"), "QaTester", "This is for qa-testers" },
                    { new Guid("9a3e8e9d-2b6d-4f6a-a5bb-5d4cd51c27ab"), "Administrator", "This is for admin" },
                    { new Guid("e4c77b0d-b1ce-49d2-80f2-c52971b6b905"), "Developer", "This is for developers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("2077cfaa-7b5d-4d6f-85d7-c76e940f6971"));

            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("9a3e8e9d-2b6d-4f6a-a5bb-5d4cd51c27ab"));

            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("e4c77b0d-b1ce-49d2-80f2-c52971b6b905"));

            migrationBuilder.InsertData(
                table: "AccessLevels",
                columns: new[] { "Id", "AccesType", "AccessDescription" },
                values: new object[,]
                {
                    { new Guid("0f2e9e4a-b535-4d6a-855a-a5d3d761eb8d"), "Administrator", "This is for admin" },
                    { new Guid("1ad9aced-ba4b-4626-abb9-ccec1fd1beca"), "QaTester", "This is for qa-testers" },
                    { new Guid("7a4b1186-41bb-4079-99da-62a22b08c1a2"), "Developer", "This is for developers" }
                });
        }
    }
}
