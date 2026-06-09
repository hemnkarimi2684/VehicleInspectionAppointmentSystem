using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.Contracts.RequestDto.TechnicalInspectionDto;

public record TechnicalInspectionCreateRequestDto(
                                                    [Required(ErrorMessage = "the Result is required",AllowEmptyStrings = false)]
                                                    [MinLength(3,ErrorMessage = "the Result characteers cannot be lower than 3")]
                                                    [MaxLength(10,ErrorMessage = "the Result characteers cannot be higher than 10")]
                                                    string Result,

                                                    [Required(ErrorMessage = "the Description is required",AllowEmptyStrings = false)]
                                                    [MinLength(2,ErrorMessage = "the Result characteers cannot be lower than 2")]
                                                    [MaxLength(250,ErrorMessage = "the Result characteers cannot be higher than 250")]
                                                    string Description,

                                                    [Required(ErrorMessage = "Issue Date is required", AllowEmptyStrings = false)]
                                                    [DataType(DataType.Date)]
                                                    DateTime IssueDate,

                                                    [Required(ErrorMessage = "the VehiclePlate is required", AllowEmptyStrings = false)]
                                                    [MinLength(0,ErrorMessage = "the VehiclePlate characteers cannot be lower than 0")]
                                                    [MaxLength(8,ErrorMessage = "the VehiclePlate characteers cannot be higher than 8")]
                                                    string VehiclePlate,

                                                    [Required(ErrorMessage = "the VehicleVin is required", AllowEmptyStrings = false)]
                                                    [MinLength(0,ErrorMessage = "the VehicleVin characteers cannot be lower than 0")]
                                                    [MaxLength(17,ErrorMessage = "the VehicleVin characteers cannot be higher than 17")]
                                                    string VehicleVin,

                                                    [Range(1, int.MaxValue,ErrorMessage = "VehicleId must be greater than 0")]
                                                    int VehicleId,

                                                    [Range(1, int.MaxValue,ErrorMessage = "AppointmentId must be greater than 0")]
                                                    int AppointmentId);

