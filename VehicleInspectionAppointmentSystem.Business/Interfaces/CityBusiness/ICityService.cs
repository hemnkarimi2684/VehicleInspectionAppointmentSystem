using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Interfaces.CityBusiness;

public interface ICityService
{
    /// <summary>
    /// دریافت شهر های یک استان
    /// </summary>
    /// <param name="provinceId"></param>
    /// <returns></returns>
    Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId);
}
