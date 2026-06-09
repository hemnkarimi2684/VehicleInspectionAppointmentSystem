using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.CityDto;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Service;

namespace VehicleInspectionAppointmentSystem.Business.Businesses.CityBusiness;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId)
    {
        var availableProvinceCities = await _cityRepository.GetCitiesByProvinceIdAsync(c => new CityResponseDto
        (
            c.Id,
            c.Name,
            c.CityCode,
            c.ProvinceCode   
        ), provinceId);

        if (availableProvinceCities == null || !availableProvinceCities.Any())
            throw new ArgumentException("We do not have any available cities in this province");

        return availableProvinceCities;
    }
}
