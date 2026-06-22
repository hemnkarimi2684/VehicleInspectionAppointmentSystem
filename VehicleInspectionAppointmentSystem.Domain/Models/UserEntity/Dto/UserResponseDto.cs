namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Dto;

public record UserResponseDto(int Id,string? FirstName, string? LastName, string? NationalCode, string? FatherName, string PhoneNumber, DateTime? BirthDate);

