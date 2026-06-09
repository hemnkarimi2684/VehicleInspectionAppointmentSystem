using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInspectionAppointmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserNameFromUserTableAndAddSomeRalationalProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Vehicles",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehiclePlate",
                table: "TechnicalInspections",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleVin",
                table: "TechnicalInspections",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceCode",
                table: "Provinces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityCode",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceCode",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CenterCode",
                table: "Centers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Plate",
                table: "Vehicles",
                column: "Plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Password",
                table: "Users",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ProvinceCode",
                table: "Provinces",
                column: "ProvinceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityCode",
                table: "Cities",
                column: "CityCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Centers_CenterCode",
                table: "Centers",
                column: "CenterCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_Plate",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Users_Password",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_ProvinceCode",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityCode",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Centers_CenterCode",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehiclePlate",
                table: "TechnicalInspections");

            migrationBuilder.DropColumn(
                name: "VehicleVin",
                table: "TechnicalInspections");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CenterCode",
                table: "Centers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }
    }
}
