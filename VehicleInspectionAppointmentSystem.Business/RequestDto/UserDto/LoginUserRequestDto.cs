using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.Business.RequestDto.UserDto;

public class LoginUserRequestDto
{
    [Required(ErrorMessage = "the UserName is required", AllowEmptyStrings = false)]
    [MinLength(3, ErrorMessage = "the UserName characters cannot be lower than 3")]
    [MaxLength(20, ErrorMessage = "the UserName characters cannot be higher than 10")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "the Password is required", AllowEmptyStrings = false)]
    [MinLength(8, ErrorMessage = "the Password characters must be 8")]
    [MaxLength(8, ErrorMessage = "the Password characters must be 8")]
    public string Password { get; set; } = string.Empty;
}
