using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("18710e16-32d1-4aad-b849-f644c4d0569d"));

            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("24e5642f-c968-49dc-8830-4ff6548f8651"));

            migrationBuilder.DeleteData(
                table: "AccessLevels",
                keyColumn: "Id",
                keyValue: new Guid("da6bb716-7a7f-4528-90e5-f749feac552c"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("18710e16-32d1-4aad-b849-f644c4d0569d"), "Administrator", "This is for admin" },
                    { new Guid("24e5642f-c968-49dc-8830-4ff6548f8651"), "Developer", "This is for developers" },
                    { new Guid("da6bb716-7a7f-4528-90e5-f749feac552c"), "QaTester", "This is for qa-testers" }
                });
        }
    }
}
