using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TimeSlotBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Dto;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeSlotController : ControllerBase
{
    private readonly ITimeSlotService _timeSlotService;

    public TimeSlotController(ITimeSlotService timeSlotService)
    {
        _timeSlotService = timeSlotService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TimeSlotResponseDto>>> GetCenterAvailableTimeSlotsAsync([FromQuery] int centerId)
    {
        var centerTimeSlots = await _timeSlotService.GetCenterAvailableTimeSlotsAsync(centerId);

        return Ok(Result<List<TimeSlotResponseDto>>.Success(centerTimeSlots));
    }
}
