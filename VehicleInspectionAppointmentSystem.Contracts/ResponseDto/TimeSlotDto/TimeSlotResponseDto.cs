namespace VehicleInspectionAppointmentSystem.Contracts.ResponseDto.TimeSlotDto;

public record TimeSlotResponseDto(int Id,TimeOnly StartTime, TimeOnly EndTime, int Capacity);

