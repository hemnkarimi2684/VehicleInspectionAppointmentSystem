using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.TimeSlotDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Service;

public interface ITimeSlotService
{
    /// <summary>
    /// دریافت زمان های قابل رزور یک مرکز
    /// </summary>
    /// <param name="centerId"></param>
    /// <returns></returns>
    Task<List<TimeSlotResponseDto>> GetCenterAvailableTimeSlotsAsync(int centerId);

    /// <summary>
    /// بررسی اینکه ایا بازه زمانی رزرو شده یا نه 
    /// </summary>
    /// <param name="timeSlotId"></param>
    /// <returns></returns>
    Task<bool> CheckTimeSlotIsReservedAsync(int timeSlotId);

    /// <summary>
    /// بررسی اینکه تایم زمانی وجود دارد یا نه 
    /// </summary>
    /// <param name="timeSlotId"></param>
    /// <returns></returns>
    Task<bool> IsExistTimeSlotAsync(int timeSlotId);

    /// <summary>
    /// اپدیت وضعیت بازه زمانی 
    /// </summary>
    /// <param name="timeSlotId"></param>
    /// <param name="isReserved"></param>
    /// <returns></returns>
    Task<bool> UpdateAppointmentReservedStatusAsync(int timeSlotId, bool isReserved);
}
