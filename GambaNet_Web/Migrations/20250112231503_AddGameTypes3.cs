using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GambaNet_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddGameTypes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 1, 13, 0, 15, 3, 165, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 1, 13, 0, 15, 3, 165, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "BackgroundBlue", "BackgroundGreen", "BackgroundRed", "Description", "GameType", "ImagePath", "Name", "Winrate" },
                values: new object[,]
                {
                    { 4, 58, 85, 34, "Vyhraješ, nebo tě potopí?", "Slot", null, "Hvězda Severu", 25 },
                    { 5, 255, 240, 210, "Cítíš ten chlad?", "Cups", null, "Zimní Vánek", 75 },
                    { 6, 40, 20, 160, "Štěstí bolí.", "Plinko", null, "Střepy Štěstí", 10 },
                    { 7, 50, 50, 50, "Jsi připraven na bitvu?", "Slot", null, "Rytířská Síla", 40 },
                    { 8, 0, 215, 255, "Co ti přinese osud?", "Cups", null, "Pohár Života", 60 },
                    { 9, 255, 100, 100, "Co se mohlo stát jinak?", "Slot", null, "Rozbité Sny", 20 },
                    { 10, 140, 180, 210, "Zvládneš přežít?", "Cups", null, "Pouštní Bouře", 30 },
                    { 11, 19, 69, 139, "Zahřeje nebo spálí?", "Plinko", null, "Horká Čokoláda", 45 },
                    { 12, 230, 216, 173, "Zmrazíš soupeře?", "Plinko", null, "Ledový Král", 55 },
                    { 13, 128, 0, 128, "Najdeš poklad?", "Slot", null, "Ztracené Město", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 13);

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
        }
    }
}
