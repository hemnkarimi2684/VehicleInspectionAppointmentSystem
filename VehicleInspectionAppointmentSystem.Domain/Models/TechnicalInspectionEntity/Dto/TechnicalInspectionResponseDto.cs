namespace VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Dto;

public record TechnicalInspectionResponseDto(string Description, DateTime IssueDate, DateTime ExpireDate, string vehiclePlate, string vehicleVin);

