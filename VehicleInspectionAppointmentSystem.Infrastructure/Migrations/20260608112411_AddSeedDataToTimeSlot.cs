using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 5, 1, null, new TimeOnly(8, 30, 0), true, new TimeOnly(8, 0, 0), new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 5, 1, null, new TimeOnly(9, 0, 0), true, new TimeOnly(8, 30, 0), new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 3, 6, 1, null, new TimeOnly(9, 30, 0), new TimeOnly(9, 0, 0), new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 4, 4, 2, null, new TimeOnly(10, 30, 0), true, new TimeOnly(10, 0, 0), new DateTime(2027, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 5, 4, 2, null, new TimeOnly(11, 0, 0), new TimeOnly(10, 30, 0), new DateTime(2027, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 6, 7, 3, null, new TimeOnly(11, 30, 0), true, new TimeOnly(11, 0, 0), new DateTime(2027, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 7, 6, 4, null, new TimeOnly(12, 30, 0), new TimeOnly(12, 0, 0), new DateTime(2027, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 8, 5, 5, null, new TimeOnly(13, 30, 0), true, new TimeOnly(13, 0, 0), new DateTime(2027, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 9, 5, 6, null, new TimeOnly(14, 0, 0), new TimeOnly(13, 30, 0), new DateTime(2027, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 10, 8, 7, null, new TimeOnly(14, 30, 0), true, new TimeOnly(14, 0, 0), new DateTime(2027, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 11, 8, 8, null, new TimeOnly(15, 0, 0), new TimeOnly(14, 30, 0), new DateTime(2027, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 12, 4, 9, null, new TimeOnly(15, 30, 0), true, new TimeOnly(15, 0, 0), new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 13, 4, 10, null, new TimeOnly(16, 0, 0), new TimeOnly(15, 30, 0), new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "IsReserved", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 14, 6, 11, null, new TimeOnly(16, 30, 0), true, new TimeOnly(16, 0, 0), new DateTime(2027, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Capacity", "CenterId", "DeletedAt", "EndTime", "StartTime", "TimeSlotDate", "UpdatedAt" },
                values: new object[] { 15, 6, 1, null, new TimeOnly(17, 0, 0), new TimeOnly(16, 30, 0), new DateTime(2027, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
