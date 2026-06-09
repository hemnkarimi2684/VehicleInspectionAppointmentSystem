using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealationBetweenTimeSlotAndAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "TimeSlots");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments",
                column: "TimeSlotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VehicleId_TimeSlotId",
                table: "Appointments",
                columns: new[] { "VehicleId", "TimeSlotId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_VehicleId_TimeSlotId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments",
                column: "VehicleId");
        }
    }
}
