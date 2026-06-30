using VehicleInspectionAppointmentSystem.Business.Common.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CityBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;

namespace VehicleInspectionAppointmentSystem.Business.Services.CityBusiness;

public class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;

    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId)
    {
        var availableProvinceCities = await _unitOfWork.CityRepository.GetCitiesByProvinceIdAsync(provinceId);

        if (availableProvinceCities == null || !availableProvinceCities.Any())
            throw new NotFoundException("We do not have any available cities in this province");

        return availableProvinceCities;
    }
}
