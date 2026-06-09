using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.ProvinceDto;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Service;

public interface IProvinceService
{
    /// <summary>
    /// دریافت تمام استان ها 
    /// </summary>
    /// <returns></returns>
    Task<List<ProvinceResponseDto>> GetAllProvinceAsync();
}
