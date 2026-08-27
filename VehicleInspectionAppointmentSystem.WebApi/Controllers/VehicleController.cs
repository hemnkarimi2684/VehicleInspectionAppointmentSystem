using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.VehicleBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VehicleResponseDto>> GetByIdAsync([FromRoute] int id)
    {
        var vehicle = await _vehicleService.GetByIdAsync(id);

        return Ok(Result<VehicleResponseDto>.Success(vehicle));
    }

    [HttpGet]
    public async Task<ActionResult<List<VehicleResponseDto>>> GetUserVehiclesAsync([FromQuery] int userId)
    {
        var userVehicles = await _vehicleService.GetUserVehiclesAsync(userId);

        return Ok(Result<List<VehicleResponseDto>>.Success(userVehicles));
    }
}
