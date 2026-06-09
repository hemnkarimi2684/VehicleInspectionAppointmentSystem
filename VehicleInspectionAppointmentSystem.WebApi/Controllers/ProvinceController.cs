using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.ProvinceDto;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Service;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProvinceController : ControllerBase
{
    private readonly IProvinceService _provinceService;

    public ProvinceController(IProvinceService provinceService)
    {
        _provinceService = provinceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProvinceResponseDto>>> GetAllAsync() => Ok(await _provinceService.GetAllProvinceAsync());

}
