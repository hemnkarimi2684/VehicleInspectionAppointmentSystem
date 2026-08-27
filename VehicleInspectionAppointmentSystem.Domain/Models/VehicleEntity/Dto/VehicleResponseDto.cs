using Microsoft.VisualBasic.FileIO;

namespace VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Dto;

public record VehicleResponseDto(int Id, string Name, string Vin, string Plate, string FuelType, int ProductionYear);

