using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.VehicleDto;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Service;

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
    public async Task<ActionResult<VehicleResponseDto>> GetByIdAsync([FromRoute] int id) => Ok(await _vehicleService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<List<VehicleResponseDto>>> GetUserVehiclesAsync([FromQuery] int userId) => Ok(await _vehicleService.GetUserVehiclesAsync(userId));
}
