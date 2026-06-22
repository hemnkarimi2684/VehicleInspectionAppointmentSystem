using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.RequestDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Business.RequestDto.PaginationDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;


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
    public async Task<IActionResult> RegisterAppointmentAsync([FromBody] AppointmentCreateRequestDto appointmentCreateDto)
    {
        var result = await _appointmentService.CreateAppointmentAsync(appointmentCreateDto);

        if (!result)
            return BadRequest("Somthing went wrong when register the appointment plaese try again!");

        return Created();
    }

    [HttpGet("vehicle/{vehicleId:int}")]
    public async Task<ActionResult<List<AppointmentDetailsResponseDto>>> GetVehicleAppointmentsAsync([FromRoute] int vehicleId) => Ok(await _appointmentService.GetVehicleAppointmentsAsync(vehicleId));

    [HttpGet]
    public async Task<ActionResult<ActionResult<List<AppointmentDetailsResponseDto>>>> GetAllWithPaginationAsync([FromQuery] PaginationRequestDto paginationRequest)
    {
        return Ok(await _appointmentService.GetAllWithPaginationAsync(paginationRequest.Page, paginationRequest.PageSize));
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
