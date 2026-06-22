using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Interfaces.CenterBusiness;

public interface ICenterService
{
    /// <summary>
    /// دریافت مرکز های فعال یک شهر
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    Task<List<CenterResponseDto>> GetActiveCentersOfCityAsync(int cityId);

    /// <summary>
    /// بررسی اینکه مرکز میتواند تایم زمان دیگری داشته باشد یا نه
    /// </summary>
    /// <param name="centerId"></param>
    /// <param name="timeSlotDate"></param>
    /// <returns></returns>
    Task<bool> CanAddTimeSlotForDayAsync(int centerId, DateTime timeSlotDate);
}
