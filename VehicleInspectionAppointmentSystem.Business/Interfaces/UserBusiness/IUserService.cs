using VehicleInspectionAppointmentSystem.Business.RequestDto.UserDto;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Interfaces.UserBusiness;

public interface IUserService
{
    /// <summary>
    /// دریافت کاربر توسط شماره تلفن
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    Task<UserResponseDto> GetUserByPhoneNumberAsync(string phoneNumber);

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
    Task<UserResponseDto> GetUserByUserNameAsync(string userName);

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
    Task<bool> UpdateCredentialsAsync(int userId, UpdateUserRequestDto updateUserRequest);

    /// <summary>
    /// ثبت نام کاربر با شماره تلفن 
    /// </summary>
    /// <param name="createUserRequest"></param>
    /// <returns></returns>
    Task<bool> RegisterAsync(CreateUserRequestDto createUserRequest);

    /// <summary>
    /// لاگین کاربر در سیستم 
    /// </summary>
    /// <param name="loginUserRequestDto"></param>
    /// <returns></returns>
    Task<bool> LoginAsync(LoginUserRequestDto loginUserRequestDto);
}
