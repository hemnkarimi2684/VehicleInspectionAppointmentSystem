using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToProvince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "DeletedAt", "Name", "ProvinceCode", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Tehran", 101, null },
                    { 2, null, "Isfahan", 102, null },
                    { 3, null, "Fars", 103, null },
                    { 4, null, "Khorasan Razavi", 104, null },
                    { 5, null, "Mazandaran", 105, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
