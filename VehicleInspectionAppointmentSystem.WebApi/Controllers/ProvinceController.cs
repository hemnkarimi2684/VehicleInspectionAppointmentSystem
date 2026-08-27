using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.ProvinceBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Dto;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

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
    public async Task<ActionResult<List<ProvinceResponseDto>>> GetAllAsync()
    {
        var provinces = await _provinceService.GetAllProvinceAsync();

        return Ok(Result<List<ProvinceResponseDto>>.Success(provinces));
    }

}
