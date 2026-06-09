using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "DeletedAt", "FatherName", "FirstName", "LastName", "NationalCode", "Password", "PhoneNumber", "Role", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "David", "John", "Smith", "1234567890", null, "09123000001", 0, null, "09123000001" },
                    { 2, new DateTime(1988, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert", "Emily", "Johnson", "1234567891", null, "09123000002", 0, null, "09123000002" },
                    { 3, new DateTime(1995, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "James", "Michael", "Williams", "1234567892", null, "09123000003", 0, null, "09123000003" },
                    { 4, new DateTime(1992, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thomas", "Sarah", "Brown", "1234567893", null, "09123000004", 0, null, "09123000004" },
                    { 5, new DateTime(1985, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "George", "David", "Jones", "1234567894", null, "09123000005", 0, null, "09123000005" },
                    { 6, new DateTime(1993, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edward", "Jessica", "Garcia", "1234567895", null, "09123000006", 0, null, "09123000006" },
                    { 7, new DateTime(1989, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Henry", "Daniel", "Miller", "1234567896", null, "09123000007", 0, null, "09123000007" },
                    { 8, new DateTime(1996, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Charles", "Laura", "Davis", "1234567897", null, "09123000008", 0, null, "09123000008" },
                    { 9, new DateTime(1980, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Root", "Admin", "System", "1234567898", "Admin@12345", "09123000009", 1, null, "admin" },
                    { 10, new DateTime(1991, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Richard", "Kevin", "Wilson", "1234567899", null, "09123000010", 0, null, "09123000010" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
