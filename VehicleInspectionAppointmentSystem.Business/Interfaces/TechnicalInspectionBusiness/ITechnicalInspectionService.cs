using VehicleInspectionAppointmentSystem.Business.RequestDto.TechnicalInspectionDto;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Interfaces.TechnicalInspectionBusiness;

public interface ITechnicalInspectionService
{
    /// <summary>
    /// ایجاد یک نتیجه معاینه فنی 
    /// </summary>
    /// <param name="inspectionCreateDto"></param>
    /// <returns></returns>
    Task<bool> CraeteTechnicalInspectionAsync(TechnicalInspectionCreateRequestDto inspectionCreateDto);

    /// <summary>
    /// دریافت تمام نتیجه ها با صفحه بندی 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<List<TechnicalInspectionResponseDto>> GetAllWithPaginationAsync(int page = 1, int pageSize = 10);

    /// <summary>
    /// دریافت سابقه نتیجه معاینه فنی های یک ماشین
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    Task<List<TechnicalInspectionResponseDto>> GetVehicleTechnicalInspectionAsync(int vehicleId);
}
