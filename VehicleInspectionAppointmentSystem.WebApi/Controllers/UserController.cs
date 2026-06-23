using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.UserBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Dto;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("by-phonenumber")]
    public async Task<ActionResult<UserResponseDto>> GetUserByPhoneNumberAsync([FromQuery] string phoneNumber)
    {
        var user = await _userService.GetUserByPhoneNumberAsync(phoneNumber);

        return Ok(Result<UserResponseDto>.Success(user));
    }

    [HttpGet("by-username")]
    public async Task<ActionResult<UserResponseDto>> GetUserByUserNameAsync([FromQuery] string userName)
    {
        var user = await _userService.GetUserByUserNameAsync(userName);

        return Ok(Result<UserResponseDto>.Success(user));
    }

    //[HttpGet]
    //public async Task<IActionResult> GetByUserNameOrPhoneNumberAsync(
    //      [FromQuery] string? userName,
    //      [FromQuery] string? phoneNumber)
    //{
    //    if(!string.IsNullOrWhiteSpace(userName))
    //        return Ok(await _userService.GetUserByUserNameAsync(userName));

    //    return Ok(await _userService.GetUserByPhoneNumberAsync(phoneNumber));
    //}
}
