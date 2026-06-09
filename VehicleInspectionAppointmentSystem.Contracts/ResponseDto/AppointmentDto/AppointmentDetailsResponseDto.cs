namespace VehicleInspectionAppointmentSystem.Contracts.ResponseDto.AppointmentDto;

public record AppointmentDetailsResponseDto(int Id, string Status, decimal Amount, int VehicleId, 
                                            string Plate, TimeOnly StartTime, TimeOnly EndTime, DateTime TimeSLotDate);

