using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.Business.RequestDto.TechnicalInspectionDto;

public class TechnicalInspectionCreateRequestDto
{
    [Required(ErrorMessage = "the Result is required", AllowEmptyStrings = false)]
    [MinLength(3, ErrorMessage = "the Result characteers cannot be lower than 3")]
    [MaxLength(10, ErrorMessage = "the Result characteers cannot be higher than 10")]
    public string Result { get; set; } = string.Empty;

    [Required(ErrorMessage = "the Description is required", AllowEmptyStrings = false)]
    [MinLength(2, ErrorMessage = "the Result characteers cannot be lower than 2")]
    [MaxLength(250, ErrorMessage = "the Result characteers cannot be higher than 250")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Issue Date is required", AllowEmptyStrings = false)]
    [DataType(DataType.Date)]
    public DateTime IssueDate { get; set; }

    [Required(ErrorMessage = "the VehiclePlate is required", AllowEmptyStrings = false)]
    [MinLength(0, ErrorMessage = "the VehiclePlate characteers cannot be lower than 0")]
    [MaxLength(8, ErrorMessage = "the VehiclePlate characteers cannot be higher than 8")]
    public string VehiclePlate { get; set; } = string.Empty;

    [Required(ErrorMessage = "the VehicleVin is required", AllowEmptyStrings = false)]
    [MinLength(0, ErrorMessage = "the VehicleVin characteers cannot be lower than 0")]
    [MaxLength(17, ErrorMessage = "the VehicleVin characteers cannot be higher than 17")]
    public string VehicleVin { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "VehicleId must be greater than 0")]
    public int VehicleId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "AppointmentId must be greater than 0")]
    public int AppointmentId { get; set; }
}


