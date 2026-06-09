using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Amount", "DeletedAt", "PaymentType", "Status", "TimeSlotId", "UpdatedAt", "VehicleId" },
                values: new object[,]
                {
                    { 1, 450000m, null, "Card", "Active", 1, null, 1 },
                    { 2, 450000m, null, "credit", "Done", 2, null, 2 },
                    { 3, 520000m, null, "Card", "Active", 4, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DeletedAt", "PaymentType", "Status", "TimeSlotId", "UpdatedAt", "VehicleId" },
                values: new object[] { 4, null, "Card", "Cancelled", 6, null, 4 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Amount", "DeletedAt", "PaymentType", "Status", "TimeSlotId", "UpdatedAt", "VehicleId" },
                values: new object[,]
                {
                    { 5, 600000m, null, "credit", "Done", 8, null, 5 },
                    { 6, 450000m, null, "Card", "Active", 10, null, 6 },
                    { 7, 300000m, null, "Card", "Done", 12, null, 7 },
                    { 8, 650000m, null, "credit", "Active", 14, null, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
