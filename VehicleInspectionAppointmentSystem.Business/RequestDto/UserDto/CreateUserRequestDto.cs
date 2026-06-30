using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.Business.RequestDto.UserDto;

public class CreateUserRequestDto
{
    [Required(ErrorMessage = "phone number is required", AllowEmptyStrings = false)]
    [Phone(ErrorMessage = "invalid phone number format")]
    [MinLength(11, ErrorMessage = "the Password characters must be 11")]
    [MaxLength(11, ErrorMessage = "the Password characters must be 11")]
    public string PhoneNumber { get; set; } = string.Empty;

}
