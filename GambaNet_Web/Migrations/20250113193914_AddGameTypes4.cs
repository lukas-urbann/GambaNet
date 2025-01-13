using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GambaNet_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddGameTypes4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 1, 13, 20, 39, 13, 844, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 1, 13, 20, 39, 13, 844, DateTimeKind.Local).AddTicks(8032));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
