using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;

namespace VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;

public interface ICenterRepository : IGenericRepository<Center>
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
