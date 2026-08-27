using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Interfaces.ProvinceBusiness;

public interface IProvinceService
{
    /// <summary>
    /// دریافت تمام استان ها 
    /// </summary>
    /// <returns></returns>
    Task<List<ProvinceResponseDto>> GetAllProvinceAsync();
}
