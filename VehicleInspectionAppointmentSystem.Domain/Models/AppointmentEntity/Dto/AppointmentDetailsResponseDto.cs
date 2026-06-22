namespace VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;

public record AppointmentDetailsResponseDto(int Id, string Status, decimal Amount, int VehicleId, 
                                            string Plate, TimeOnly StartTime, TimeOnly EndTime, DateTime TimeSLotDate);

