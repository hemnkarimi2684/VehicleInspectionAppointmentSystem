using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace VehicleInspectionAppointmentSystem.Business.RequestDto.AppointmentDto;

public class AppointmentCreateRequestDto
{
    [Required(ErrorMessage = "the status is required", AllowEmptyStrings = false)]
    [MinLength(3, ErrorMessage = "the status characteers cannot be lower than 3")]
    [MaxLength(10, ErrorMessage = "the status characteers cannot be higher than 10")]
    public string Status { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "the amount must be in the range")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "the PaymentType  is required", AllowEmptyStrings = false)]
    [MinLength(3, ErrorMessage = "the PaymentType characteers cannot be lower than 3")]
    [MaxLength(10, ErrorMessage = "the PaymentType characteers cannot be higher than 10")]
    public string PaymentType { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "the VehicleId must be greater than 0")]
    public int VehicleId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "the TimeSlotId must be greater than 0")]
    public int TimeSlotId { get; set; }
}
