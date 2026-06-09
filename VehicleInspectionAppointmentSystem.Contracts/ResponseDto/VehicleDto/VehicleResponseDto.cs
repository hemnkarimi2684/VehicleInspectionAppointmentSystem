using Microsoft.VisualBasic.FileIO;

namespace VehicleInspectionAppointmentSystem.Contracts.ResponseDto.VehicleDto;

public record VehicleResponseDto(int Id, string Name, string Vin, string Plate, string FuelType, int ProductionYear);

