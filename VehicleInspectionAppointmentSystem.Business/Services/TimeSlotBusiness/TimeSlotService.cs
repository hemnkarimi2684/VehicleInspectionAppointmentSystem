using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Dto;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TimeSlotBusiness;
using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;

namespace VehicleInspectionAppointmentSystem.Business.Services.TimeSlotBusiness;

public class TimeSlotService : ITimeSlotService
{
    private readonly IUnitOfWork _unitOfWork;

    public TimeSlotService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CheckTimeSlotIsReservedAsync(int timeSlotId)
    {
        var result = await _unitOfWork.TimeSlotRepository.CheckTimeSlotIsReservedAsync(timeSlotId);

        if (result)
            throw new ArgumentException("dear user this time slot is reserved :(");

        return result;
    }

    public async Task<List<TimeSlotResponseDto>> GetCenterAvailableTimeSlotsAsync(int centerId)
    {
        var centerAvailableTimeSlots = await _unitOfWork.TimeSlotRepository.GetCenterAvailableTimeSlotsAsync(centerId);

        if (centerAvailableTimeSlots == null || !centerAvailableTimeSlots.Any())
            throw new NotFoundException("Our center is currently unable to serve you");

        return centerAvailableTimeSlots;
    }

    public async Task<bool> IsExistTimeSlotAsync(int timeSlotId)
    {
        var isExistTimeSlot = await _unitOfWork.TimeSlotRepository.IsExistTimeSlotAsync(timeSlotId);

        if (!isExistTimeSlot)
            throw new NotFoundException("this timeSlot id not exist in the system!");

        return isExistTimeSlot;
    }

    public async Task<bool> UpdateAppointmentReservedStatusAsync(int timeSlotId, bool isReserved)
    {
        var result = await _unitOfWork.TimeSlotRepository.UpdateAppointmentReservedStatusAsync(timeSlotId, isReserved);

        if (!result)
            throw new ValidationException($"the time slot with this {timeSlotId} not found or something went wrong with save changes");

        return result;
    }
}
