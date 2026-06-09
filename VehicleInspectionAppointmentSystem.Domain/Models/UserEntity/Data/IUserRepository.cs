using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;

public interface IUserRepository : IGenericRepository<User>
{
    /// <summary>
    /// دریافت کاربر توسط شماره تلفن
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    Task<User?> GetUserByPhoneNumberAsync(string phoneNumber);

    /// <summary>
    /// چک کردن ایا کاربری بااین شماره وجود دارد یا نه
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    Task<bool> AnyUserWithThisPhoneNumberAsync(string phoneNumber);

    /// <summary>
    /// دریافت کاربر توسط نام کاربری 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<User?> GetUserByUserNameAsync(string userName);

    /// <summary>
    /// چک کردن ایا کاربری بااین نام کاربری وجود دارد یا نه 
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    Task<bool> AnyUserWithThisUserNameAsync(string userName);

    /// <summary>
    /// چک کردن اینکه کاربر رمز عبور دارد یا نه 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<bool> CheckUserHasPasswordAsync(int userId);

    /// <summary>
    /// اپدیت نام کاربری و رمز عبور کاربر
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<bool> UpdateCredentialsAsync(int userId, string userName, string password);
}
