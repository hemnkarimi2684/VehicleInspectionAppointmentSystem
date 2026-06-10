using Microsoft.AspNetCore.Mvc;
using VehicleInspectionAppointmentSystem.Contracts.RequestDto.PaginationDto;
using VehicleInspectionAppointmentSystem.Contracts.RequestDto.TechnicalInspectionDto;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.TechnicalInspectionDto;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

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
    public async Task<IActionResult> RegisterTechnicalInspection([FromBody] TechnicalInspectionCreateRequestDto technicalInspectionCreateDto)
    {
        var result = await _technicalInspectionService.CraeteTechnicalInspectionAsync(technicalInspectionCreateDto);

        if (!result)
            return BadRequest("Somthing went wrong when register the technical inspection plaese try again!");

        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<List<TechnicalInspectionResponseDto>>> GetAllWithPaginationAsync([FromQuery] PaginationRequestDto paginationRequest)
    {
        return Ok(await _technicalInspectionService.GetAllWithPaginationAsync(paginationRequest.Page, paginationRequest.PageSize));
    }

    [HttpGet("vehicle/{vehicleId:int}")]
    public async Task<ActionResult<List<TechnicalInspectionResponseDto>>> GetVehicleTechnicalInspectionAsync([FromRoute] int vehicleId)
    {
        return Ok(await _technicalInspectionService.GetVehicleTechnicalInspectionAsync(vehicleId));
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
