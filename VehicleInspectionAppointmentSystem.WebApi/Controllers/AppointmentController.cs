using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.RequestDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Business.RequestDto.PaginationDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.WebApi.Filters;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;


namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    [RequestModelValidationFilter]
    public async Task<IActionResult> RegisterAppointmentAsync([FromBody] AppointmentCreateRequestDto appointmentCreateDto)
    {
        await _appointmentService.CreateAppointmentAsync(appointmentCreateDto);

        return Ok(Result.Success());
    }

    [HttpGet("vehicle/{vehicleId:int}")]
    public async Task<ActionResult<List<AppointmentDetailsResponseDto>>> GetVehicleAppointmentsAsync([FromRoute] int vehicleId)
    {
        var vehicleAppointments = await _appointmentService.GetVehicleAppointmentsAsync(vehicleId);

        return Ok(Result<List<AppointmentDetailsResponseDto>>.Success(vehicleAppointments));
    }

    [HttpGet]
    public async Task<ActionResult<ActionResult<List<AppointmentDetailsResponseDto>>>> GetAllWithPaginationAsync([FromQuery] PaginationRequestDto paginationRequest)
    {
        var appointments = await _appointmentService.GetAllWithPaginationAsync(paginationRequest.Page, paginationRequest.PageSize);

        return Ok(Result<List<AppointmentDetailsResponseDto>>.Success(appointments));
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllAppointmentAsync(
    //       [FromQuery] PaginationRequestDto paginationRequest,
    //       [FromQuery] int? vehicleId)
    //{
    //    if (vehicleId != null)
    //      return  Ok(await _appointmentService.GetVehicleAppointmentsAsync(vehicleId.Value));

    //    return Ok(await _appointmentService.GetAllWithPaginationAsync(paginationRequest.Page, paginationRequest.PageSize));
    //}
}
