using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TechnicalInspectionBusiness;
using VehicleInspectionAppointmentSystem.Business.RequestDto.PaginationDto;
using VehicleInspectionAppointmentSystem.Business.RequestDto.TechnicalInspectionDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Dto;
using VehicleInspectionAppointmentSystem.WebApi.Filters;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

namespace VehicleInspectionAppointmentSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnicalInspectionController : ControllerBase
{
    private readonly ITechnicalInspectionService _technicalInspectionService;

    public TechnicalInspectionController(ITechnicalInspectionService technicalInspectionService)
    {
        _technicalInspectionService = technicalInspectionService;
    }

    [HttpPost]
    [RequestModelValidationFilter]
    public async Task<IActionResult> RegisterTechnicalInspection([FromBody] TechnicalInspectionCreateRequestDto technicalInspectionCreateDto)
    {
        await _technicalInspectionService.CraeteTechnicalInspectionAsync(technicalInspectionCreateDto);

        return Ok(Result.Success());
    }

    [HttpGet]
    public async Task<ActionResult<List<TechnicalInspectionResponseDto>>> GetAllWithPaginationAsync([FromQuery] PaginationRequestDto paginationRequest)
    {
        var technicalInspections = await _technicalInspectionService.GetAllWithPaginationAsync(paginationRequest.Page, paginationRequest.PageSize);

        return Ok(Result<List<TechnicalInspectionResponseDto>>.Success(technicalInspections));
    }

    [HttpGet("vehicle/{vehicleId:int}")]
    public async Task<ActionResult<List<TechnicalInspectionResponseDto>>> GetVehicleTechnicalInspectionAsync([FromRoute] int vehicleId)
    {
        var vehcileTechnicalInspections = await _technicalInspectionService.GetVehicleTechnicalInspectionAsync(vehicleId);

        return Ok(Result<List<TechnicalInspectionResponseDto>>.Success(vehcileTechnicalInspections));
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllTechnicalInspectionAsync(
    //    [FromQuery] PaginationRequestDto paginationRequest,
    //    [FromQuery] int? vehicleId)
    //{
    //    if (vehicleId != null)
    //        return Ok(await _technicalInspectionService.GetVehicleTechnicalInspectionAsync(vehicleId.Value));

    //    return Ok(await _technicalInspectionService.GetAllWithPaginationAsync(paginationRequest.Page, paginationRequest.PageSize));
    //}
}
