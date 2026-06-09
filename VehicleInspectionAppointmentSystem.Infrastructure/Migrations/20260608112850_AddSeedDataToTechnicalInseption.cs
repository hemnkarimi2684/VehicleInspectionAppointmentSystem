using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToTechnicalInseption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TechnicalInspections",
                columns: new[] { "Id", "AppointmentId", "DeletedAt", "Description", "ExpireDate", "IssueDate", "Result", "UpdatedAt", "VehicleId", "VehiclePlate", "VehicleVin" },
                values: new object[,]
                {
                    { 1, 1, null, "Vehicle passed all technical and emission checks successfully.", new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passed", null, 1, "12A34567", "JTDBR32E530123456" },
                    { 2, 2, null, "Inspection completed successfully with no critical issues.", new DateTime(2027, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passed", null, 2, "23B45678", "JHMFA16586S123456" },
                    { 3, 3, null, "Vehicle failed due to brake system performance below standard.", new DateTime(2027, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Failed", null, 3, "34C56789", "5YJ3E1EA7KF123456" },
                    { 4, 5, null, "Inspection rejected because required vehicle documents were incomplete.", new DateTime(2027, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", null, 5, "56E78901", "WF0XXXTTGXK123456" },
                    { 5, 7, null, "Motorcycle passed safety, lighting and emission inspection.", new DateTime(2027, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passed", null, 7, "78G90123", "MLHPC4567M5123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TechnicalInspections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechnicalInspections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechnicalInspections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TechnicalInspections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TechnicalInspections",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
