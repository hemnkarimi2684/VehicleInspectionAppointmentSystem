using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.Contracts.RequestDto.PaginationDto;

public record PaginationRequestDto(
                                    [Range(0, int.MaxValue,ErrorMessage = "Value must be greater than 0")]
                                    int Page = 1,

                                    [Range(1, int.MaxValue,ErrorMessage = "Value must be greater than 0")]
                                    int PageSize = 10);

