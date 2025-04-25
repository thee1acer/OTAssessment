using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.Database.Migrations
{
    /// <inheritdoc />
    public partial class Updatedalltables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Wagers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Wagers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Wagers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Wagers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Wagers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Wagers",
                type: "datetime2",
                nullable: true);
        }
    }
}
