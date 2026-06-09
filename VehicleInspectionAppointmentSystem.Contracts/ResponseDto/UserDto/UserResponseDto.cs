namespace VehicleInspectionAppointmentSystem.Contracts.ResponseDto.UserDto;

public record UserResponseDto(int Id,string? FirstName, string? LastName, string? NationalCode, string? FatherName, string PhoneNumber, DateTime? BirthDate);

