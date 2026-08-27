using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CenterBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

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
    public async Task<ActionResult<List<CenterResponseDto>>> GetActiveCentersOfCityAsync([FromQuery] int cityId)
    {
        var activeCityCenters = await _centerService.GetActiveCentersOfCityAsync(cityId);

        return Ok(Result<List<CenterResponseDto>>.Success(activeCityCenters));
    }
}
