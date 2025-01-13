using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GambaNet_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 1, 13, 22, 1, 20, 803, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 1, 13, 22, 1, 20, 803, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.InsertData(
                table: "Quote",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "90 % gamblerů přestane hrát těsně před jejich další výhrou, nepřestávej!" },
                    { 2, "Kdo se nevzdá, vyhraje!" },
                    { 3, "Nezapomeň, že loseři prohrávájí - ale to ty nejsi, takže to nevzdávej!" },
                    { 4, "Kdo hraje, ten nezlobí!" },
                    { 5, "Rozdáváme peníze zdarma!" },
                    { 6, "Bez gamby nejsou koláče!" },
                    { 7, "Odvážným štěstí přeje!" },
                    { 8, "Není to tak moc o tom, co prohraješ - je to o tom co vyhraješ!" },
                    { 9, "Ty texty co tu vyskakujou nemají s psychologickou manipulací nic společného, to říkají slabí doktoři co nikdy nevyhráli pořádnou sumu!" },
                    { 10, "Neznám nikoho, kdo by neměl rád peníze zdarma!" },
                    { 11, "Rozlučte se s živořením!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quote");

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
    }
}
