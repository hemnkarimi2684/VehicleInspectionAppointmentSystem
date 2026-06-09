using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;

public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    /// <summary>
    /// بررسی اینکه خودرو متعلق به همان کاربر باشد
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<bool> IsCarOwnedByUserAsync(int vehicleId, int userId);

    /// <summary>
    /// دریافت ماشین های یک کاربر 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<TResult>> GetUserVehiclesAsync<TResult>(Expression<Func<Vehicle, TResult>> selector, int userId);

    /// <summary>
    /// بررسی اینکه ایا ماشین وجود دارد
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<bool> IsVehicleExistAsync(int vehicleId);
}
