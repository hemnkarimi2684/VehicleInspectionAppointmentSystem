using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CityBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Services.CityBusiness;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId)
    {
        var availableProvinceCities = await _cityRepository.GetCitiesByProvinceIdAsync(provinceId);

        if (availableProvinceCities == null || !availableProvinceCities.Any())
            throw new NotFoundException("We do not have any available cities in this province");

        return availableProvinceCities;
    }
}
