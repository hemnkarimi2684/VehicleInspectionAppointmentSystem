namespace VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Dto;

public record TimeSlotResponseDto(int Id,TimeOnly StartTime, TimeOnly EndTime, int Capacity);

