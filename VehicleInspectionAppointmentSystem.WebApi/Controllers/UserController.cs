using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.UserDto;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Service;

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
    public async Task<ActionResult<UserResponseDto>> GetUserByPhoneNumberAsync([FromQuery] string phoneNumber) => Ok(await _userService.GetUserByPhoneNumberAsync(phoneNumber));

    [HttpGet("by-username")]
    public async Task<ActionResult<UserResponseDto>> GetUserByUserNameAsync([FromQuery] string userName) => Ok(await _userService.GetUserByUserNameAsync(userName));

    [HttpGet]
    public async Task<IActionResult> GetByUserNameOrPhoneNumberAsync(
          [FromQuery] string? userName,
          [FromQuery] string? phoneNumber)
    {
        if(!string.IsNullOrWhiteSpace(userName))
            return Ok(await _userService.GetUserByUserNameAsync(userName));

        return Ok(await _userService.GetUserByPhoneNumberAsync(phoneNumber));
    }
}
