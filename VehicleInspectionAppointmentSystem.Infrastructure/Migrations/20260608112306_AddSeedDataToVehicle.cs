using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "DeletedAt", "FuelType", "IsActive", "ManufacturerCompany", "Name", "Plate", "ProductionYear", "UpdatedAt", "UserId", "VehicleType", "Vin" },
                values: new object[,]
                {
                    { 1, "Toyota", "White", null, "Gasoline", true, "Toyota Motor Corporation", "Corolla", "12A34567", 2018, null, 1, "Ride", "JTDBR32E530123456" },
                    { 2, "Honda", "Black", null, "Gasoline", true, "Honda Motor Company", "Civic", "23B45678", 2019, null, 2, "Ride", "JHMFA16586S123456" },
                    { 3, "Tesla", "Blue", null, "Electricity", true, "Tesla Inc", "Model Three", "34C56789", 2021, null, 3, "Ride", "5YJ3E1EA7KF123456" },
                    { 4, "Mercedes", "Silver", null, "CNG", true, "Mercedes Benz Trucks", "Actros", "45D67890", 2017, null, 4, "Truck", "WDB9634031L123456" },
                    { 5, "Ford", "White", null, "Gasoline", true, "Ford Motor Company", "Transit", "56E78901", 2016, null, 5, "Bus", "WF0XXXTTGXK123456" },
                    { 6, "Toyota", "Red", null, "SuperGasoline", true, "Toyota Motor Corporation", "Yaris", "67F89012", 2020, null, 6, "Taxi", "JTDKT923975123456" },
                    { 7, "Honda", "Red", null, "Gasoline", true, "Honda Motor Company", "CBR", "78G90123", 2022, null, 7, "Motorcycle", "MLHPC4567M5123456" },
                    { 8, "Toyota", "Gray", null, "CNG", true, "Toyota Motor Corporation", "Hilux", "89H01234", 2015, null, 8, "Truck", "MR0EX3CD901123456" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "DeletedAt", "FuelType", "ManufacturerCompany", "Name", "Plate", "ProductionYear", "UpdatedAt", "UserId", "VehicleType", "Vin" },
                values: new object[] { 9, "Toyota", "Black", null, "Gasoline", "Toyota Motor Corporation", "Camry", "90J12345", 2018, null, 10, "Ride", "4T1BF1FK5HU123456" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "DeletedAt", "FuelType", "IsActive", "ManufacturerCompany", "Name", "Plate", "ProductionYear", "UpdatedAt", "UserId", "VehicleType", "Vin" },
                values: new object[,]
                {
                    { 10, "Mercedes", "White", null, "CNG", true, "Mercedes Benz Vans", "Sprinter", "11K23456", 2014, null, 1, "Bus", "WD3PE8CC6D5123456" },
                    { 11, "Honda", "Silver", null, "SuperGasoline", true, "Honda Motor Company", "Accord", "22L34567", 2019, null, 2, "Ride", "1HGCV1F34JA123456" },
                    { 12, "Ford", "Green", null, "Gasoline", true, "Ford Motor Company", "Ranger", "33M45678", 2020, null, 3, "Truck", "1FTER4FH5KLA12345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
