using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GambaNet_Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxBet",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "MinBet",
                table: "Game");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Plinko description", "Plinko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxBet",
                table: "Game",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinBet",
                table: "Game",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxBet", "MinBet", "Name" },
                values: new object[] { 1000m, 10m, "Casiino" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxBet", "MinBet", "Name" },
                values: new object[] { 1000m, 10m, "Cassino roon" });
        }
    }
}
