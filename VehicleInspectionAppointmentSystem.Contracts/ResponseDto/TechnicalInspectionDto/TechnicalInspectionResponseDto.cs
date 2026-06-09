namespace VehicleInspectionAppointmentSystem.Contracts.ResponseDto.TechnicalInspectionDto;

public record TechnicalInspectionResponseDto(string Description, DateTime IssueDate, DateTime ExpireDate, string vehiclePlate, string vehicleVin);

