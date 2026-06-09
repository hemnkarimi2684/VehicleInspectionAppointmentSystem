using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityCode", "DeletedAt", "Name", "ProvinceCode", "ProvinceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 101, null, "Tehran", 21, 1, null },
                    { 2, 102, null, "Rey", 21, 1, null },
                    { 3, 201, null, "Isfahan", 31, 2, null },
                    { 4, 202, null, "Kashan", 31, 2, null },
                    { 5, 301, null, "Shiraz", 71, 3, null },
                    { 6, 302, null, "Marvdasht", 71, 3, null },
                    { 7, 401, null, "Mashhad", 51, 4, null },
                    { 8, 402, null, "Neyshabur", 51, 4, null },
                    { 9, 501, null, "Tabriz", 41, 5, null },
                    { 10, 502, null, "Maragheh", 41, 5, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
