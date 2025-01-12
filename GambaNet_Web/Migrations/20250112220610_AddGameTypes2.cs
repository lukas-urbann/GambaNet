using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GambaNet_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddGameTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameType",
                table: "Game",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 1, 12, 23, 6, 10, 201, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 1, 12, 23, 6, 10, 201, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameType",
                value: "Cups");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameType",
                value: "Slot");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameType",
                value: "Plinko");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameType",
                table: "Game");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 1, 12, 22, 38, 48, 32, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 1, 12, 22, 38, 48, 32, DateTimeKind.Local).AddTicks(650));
        }
    }
}
