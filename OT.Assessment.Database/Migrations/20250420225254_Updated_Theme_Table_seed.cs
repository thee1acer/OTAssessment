using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Theme_Table_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62d70655-06ee-4dd0-946d-086fa78b1cbb"), "retro" },
                    { new Guid("9fa0c14b-5392-4b49-a30f-e3b84e68cdcf"), "jungle" },
                    { new Guid("b19ef2b3-3d64-45b6-a6f2-c2d22c7a7cd4"), "family" },
                    { new Guid("b7a1a8fc-4f43-4b79-9c8d-2c3c8a3f87d0"), "ancient" },
                    { new Guid("c4b219c5-fbd9-4d62-a13d-f1b4eb19d9ec"), "crash" },
                    { new Guid("e8d4d3ef-83b9-4c93-8d3e-6df56f20f1a1"), "adventure" },
                    { new Guid("f55dbdab-d29f-4f01-9c6d-56b3791fc2f7"), "wildlife" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("62d70655-06ee-4dd0-946d-086fa78b1cbb"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("9fa0c14b-5392-4b49-a30f-e3b84e68cdcf"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("b19ef2b3-3d64-45b6-a6f2-c2d22c7a7cd4"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("b7a1a8fc-4f43-4b79-9c8d-2c3c8a3f87d0"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("c4b219c5-fbd9-4d62-a13d-f1b4eb19d9ec"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("e8d4d3ef-83b9-4c93-8d3e-6df56f20f1a1"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("f55dbdab-d29f-4f01-9c6d-56b3791fc2f7"));
        }
    }
}
