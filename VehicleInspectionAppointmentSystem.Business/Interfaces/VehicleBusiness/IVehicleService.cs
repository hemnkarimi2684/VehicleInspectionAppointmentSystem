using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Interfaces.VehicleBusiness;

public interface IVehicleService
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
    Task<List<VehicleResponseDto>> GetUserVehiclesAsync(int userId);

    /// <summary>
    /// بررسی اینکه ایا ماشین وجود دارد
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<bool> IsVehicleExistAsync(int vehicleId);

    /// <summary>
    /// دریافت یک موجودیت با ایدی 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<VehicleResponseDto> GetByIdAsync(int id, bool tracking = false);
}
