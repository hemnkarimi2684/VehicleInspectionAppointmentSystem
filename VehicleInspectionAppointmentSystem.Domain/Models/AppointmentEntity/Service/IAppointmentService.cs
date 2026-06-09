using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Contracts.RequestDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Service;

public interface IAppointmentService
{
   
    /// <summary>
    /// بررسی اینکه خودرو در همان زمان، نوبت فعال دیگری نداشته باشد
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<bool> HasActiveAppointmentAtTimeAsync(int vehicleId, int timeSlotId);

    /// <summary>
    /// بررسی اینکه نوبت فعال دیگری نداشته باشد
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<bool> HasActiveAppointmentAsync(int vehicleId);

    /// <summary>
    /// ثبت یک نوبت 
    /// </summary>
    /// <param name="appointmentCreate"></param>
    /// <returns></returns>
    Task<bool> CreateAppointmentAsync(AppointmentCreateRequestDto appointmentCreate);

    /// <summary>
    /// بررسی اینکه ایا نوبت برای ماشین مورد نظر است یا نه
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="appointmentId"></param>
    /// <returns></returns>
    Task<bool> HasActiveAppointmentBelongToVehicleAsync(int vehicleId, int appointmentId);

    /// <summary>
    /// بررسی اینکه ایا نوبت به پایان رسیده یا نه
    /// </summary>
    /// <param name="appointmentId"></param>
    /// <returns></returns>
    Task<bool> CheckAppointmentStatusIsDoneAsync(int appointmentId);

    /// <summary>
    /// دریافت نوبت های یک ماشین
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<List<AppointmentDetailsResponseDto>> GetVehicleAppointmentsAsync(int vehicleId);

    /// <summary>
    /// دریافت همه نوبت ها
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tracking"></param>
    /// <returns></returns>
    Task<List<AppointmentDetailsResponseDto>> GetAllWithPaginationAsync(int page, int pageSize);


}
