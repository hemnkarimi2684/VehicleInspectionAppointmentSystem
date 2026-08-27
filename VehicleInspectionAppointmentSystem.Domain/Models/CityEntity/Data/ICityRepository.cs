using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;

namespace VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;

public interface ICityRepository : IGenericRepository<City>
{
    /// <summary>
    /// دریافت شهر های یک استان
    /// </summary>
    /// <param name="provinceId"></param>
    /// <returns></returns>
    Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId);
}
