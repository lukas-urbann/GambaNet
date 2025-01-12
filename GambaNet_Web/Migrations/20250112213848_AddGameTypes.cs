using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GambaNet_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddGameTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BackgroundBlue",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackgroundGreen",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackgroundRed",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Winrate",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ads",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BackgroundBlue", "BackgroundGreen", "BackgroundRed", "Description", "Name", "Winrate" },
                values: new object[] { 39, 179, 230, "Máš na to ?", "Láska Strejdy", 100 });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BackgroundBlue", "BackgroundGreen", "BackgroundRed", "Description", "Name", "Winrate" },
                values: new object[] { 230, 80, 39, "Kde to jen bylo", "Léto v Čečensku", 50 });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BackgroundBlue", "BackgroundGreen", "BackgroundRed", "Description", "Name", "Winrate" },
                values: new object[] { 169, 138, 189, "Proč to musel udělat", "Igor Hnízdo", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundBlue",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "BackgroundGreen",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "BackgroundRed",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Winrate",
                table: "Game");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ads",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 1, 11, 13, 23, 14, 437, DateTimeKind.Local).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 1, 11, 13, 23, 14, 437, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Slots machine description", "Slots" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Cups description", "Cups" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Plinko description", "Plinko" });
        }
    }
}
