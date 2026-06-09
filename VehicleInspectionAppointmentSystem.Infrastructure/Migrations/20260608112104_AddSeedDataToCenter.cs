using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Centers",
                columns: new[] { "Id", "Address", "CenterCode", "CityId", "DailyMaxCapacity", "DeletedAt", "ManagerName", "Name", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "No. 15, Shariati Street, Tehran", 1001, 1, 20, null, "Michael Anderson", "North Tehran Technical Inspection Center", "09121001001", null },
                    { 2, "No. 42, Azadi Avenue, Tehran", 1002, 1, 18, null, "Daniel Brown", "West Tehran Vehicle Inspection Center", "09121001002", null },
                    { 3, "No. 8, Imam Street, Rey", 1003, 2, 15, null, "Robert Wilson", "Rey Central Inspection Center", "09121001003", null },
                    { 4, "No. 22, Chaharbagh Avenue, Isfahan", 2001, 3, 20, null, "James Miller", "Isfahan Main Inspection Center", "09121002001", null },
                    { 5, "No. 11, Fin Road, Kashan", 2002, 4, 14, null, "William Davis", "Kashan Vehicle Safety Center", "09121002002", null },
                    { 6, "No. 31, Zand Boulevard, Shiraz", 3001, 5, 20, null, "Thomas Moore", "Shiraz Central Technical Inspection", "09121003001", null },
                    { 7, "No. 19, Persepolis Road, Marvdasht", 3002, 6, 12, null, "Christopher Taylor", "Marvdasht Vehicle Inspection Station", "09121003002", null },
                    { 8, "No. 61, Vakilabad Boulevard, Mashhad", 4001, 7, 19, null, "Matthew Clark", "Mashhad East Inspection Center", "09121004001", null },
                    { 9, "No. 5, Attar Street, Neyshabur", 4002, 8, 13, null, "Anthony Lewis", "Neyshabur Technical Inspection Center", "09121004002", null },
                    { 10, "No. 77, Elgoli Road, Tabriz", 5001, 9, 20, null, "Mark Walker", "Tabriz Main Vehicle Inspection Center", "09121005001", null },
                    { 11, "No. 14, Sahand Avenue, Maragheh", 5002, 10, 11, null, "Steven Hall", "Maragheh Road Safety Inspection Center", "09121005002", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
