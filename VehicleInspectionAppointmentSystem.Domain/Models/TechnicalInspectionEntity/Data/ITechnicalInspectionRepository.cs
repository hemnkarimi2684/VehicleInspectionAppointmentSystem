using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;

public interface ITechnicalInspectionRepository : IGenericRepository<TechnicalInspection>
{
    /// <summary>
    /// یررسی کردن اینکه ماشین معاینه فنی  فعال دارد یا نه
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<bool> VehicleHasTechnicalInspectionAsync(int vehicleId);

    /// <summary>
    /// دریافت سابقه نتیجه معاینه فنی های یک ماشین
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="selector"></param>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<List<TResult>> GetVehicleTechnicalInspectionAsync<TResult>(Expression<Func<TechnicalInspection, TResult>> selector, int vehicleId);
}
