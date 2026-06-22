using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Dto;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TimeSlotBusiness;

namespace VehicleInspectionAppointmentSystem.Business.Services.TimeSlotBusiness;

public class TimeSlotService : ITimeSlotService
{
    private readonly ITimeSlotRepository _timeSlotRepository;

    public TimeSlotService(ITimeSlotRepository timeSlotRepository)
    {
        _timeSlotRepository = timeSlotRepository;
    }

    public async Task<bool> CheckTimeSlotIsReservedAsync(int timeSlotId)
    {
        var result = await _timeSlotRepository.CheckTimeSlotIsReservedAsync(timeSlotId);

        if (result)
            throw new ArgumentException("dear user this time slot is reserved :(");

        return result;
    }

    public async Task<List<TimeSlotResponseDto>> GetCenterAvailableTimeSlotsAsync(int centerId)
    {
        var centerAvailableTimeSlots = await _timeSlotRepository.GetCenterAvailableTimeSlotsAsync(centerId);

        if (centerAvailableTimeSlots == null || !centerAvailableTimeSlots.Any())
            throw new ArgumentException("Our center is currently unable to serve you");

        return centerAvailableTimeSlots;
    }

    public async Task<bool> IsExistTimeSlotAsync(int timeSlotId)
    {
        var isExistTimeSlot = await _timeSlotRepository.IsExistTimeSlotAsync(timeSlotId);

        if (!isExistTimeSlot)
            throw new InvalidOperationException("this timeSlot id not exist in the system!");

        return isExistTimeSlot;
    }

    public async Task<bool> UpdateAppointmentReservedStatusAsync(int timeSlotId, bool isReserved)
    {
        var result = await _timeSlotRepository.UpdateAppointmentReservedStatusAsync(timeSlotId, isReserved);

        if (!result)
            throw new InvalidOperationException($"the time slot with this {timeSlotId} not found or something went wrong with save changes");

        return result;
    }
}
