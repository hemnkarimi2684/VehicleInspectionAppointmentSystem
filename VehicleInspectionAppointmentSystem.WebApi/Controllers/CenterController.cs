using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CenterBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CenterController : ControllerBase
{
    private readonly ICenterService _centerService;

    public CenterController(ICenterService centerService)
    {
        _centerService = centerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CenterResponseDto>>> GetActiveCentersOfCityAsync([FromQuery] int cityId) => Ok(await _centerService.GetActiveCentersOfCityAsync(cityId));
}
