using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;

namespace VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;

public interface IAppointmentRepository : IGenericRepository<Appointment>
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
    Task<List<TResult>> GetVehicleAppointmentsAsync<TResult>(Expression<Func<Appointment, TResult>> selector, int vehicleId);
}
