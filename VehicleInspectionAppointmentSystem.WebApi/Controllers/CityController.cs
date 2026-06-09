using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.CityDto;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Service;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<ActionResult<CityResponseDto>> GetCitiesByProvinceIdAsync([FromQuery] int provinceId) => Ok(await _cityService.GetCitiesByProvinceIdAsync(provinceId));

}
