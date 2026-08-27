using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.Business.RequestDto.PaginationDto;

public class PaginationRequestDto
{
    [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
    public int Page { get; set; } = 1;

    [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
    public int PageSize { get; set; } = 10;
}

