using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.CityDto;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Service;

public interface ICityService
{
    /// <summary>
    /// دریافت شهر های یک استان
    /// </summary>
    /// <param name="provinceId"></param>
    /// <returns></returns>
    Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId);
}
