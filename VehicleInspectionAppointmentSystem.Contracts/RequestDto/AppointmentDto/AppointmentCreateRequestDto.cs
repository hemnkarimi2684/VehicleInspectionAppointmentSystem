using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace VehicleInspectionAppointmentSystem.Contracts.RequestDto.AppointmentDto;

public record AppointmentCreateRequestDto(
                                            [Required(ErrorMessage = "the status is required", AllowEmptyStrings = false)]
                                            [MinLength(3,ErrorMessage = "the status characteers cannot be lower than 3")]
                                            [MaxLength(10,ErrorMessage = "the status characteers cannot be higher than 10")]
                                            string Status,

                                            [Range(0,double.MaxValue,ErrorMessage = "the amount must be in the range")]
                                            decimal Amount,

                                            [Required(ErrorMessage = "the status is required", AllowEmptyStrings = false)]
                                            [MinLength(3,ErrorMessage = "the PaymentType characteers cannot be lower than 3")]
                                            [MaxLength(10,ErrorMessage = "the PaymentType characteers cannot be higher than 10")]
                                            string PaymentType,

                                            [Range(1,int.MaxValue,ErrorMessage = "the VehicleId must be greater than 0")]
                                            int VehicleId,

                                            [Range(1,int.MaxValue,ErrorMessage = "the TimeSlotId must be greater than 0")]
                                            int TimeSlotId 
                                        );

