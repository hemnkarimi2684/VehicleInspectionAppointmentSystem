using VehicleInspectionAppointmentSystem.Business.Interfaces.CenterBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Services.CenterBusiness;

public class CenterService : ICenterService
{
    private readonly ICenterRepository _centerRepository;

    public CenterService(ICenterRepository centerRepository)
    {
        _centerRepository = centerRepository;
    }

    public async Task<bool> CanAddTimeSlotForDayAsync(int centerId, DateTime timeSlotDate)
    {
        var result = await _centerRepository.CanAddTimeSlotForDayAsync(centerId, timeSlotDate);

        if (!result)
            throw new InvalidOperationException("Today's capacity of this technical examination is full");

        return result;
    }

    public async Task<List<CenterResponseDto>> GetActiveCentersOfCityAsync(int cityId)
    {
        var availableCityCenters = await _centerRepository.GetActiveCentersOfCityAsync(cityId);

        if (availableCityCenters == null || !availableCityCenters.Any())
            throw new ArgumentException("We do not have any available centers in this city");

        return availableCityCenters;
    }
}
