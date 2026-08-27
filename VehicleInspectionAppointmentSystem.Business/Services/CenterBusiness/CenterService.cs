using VehicleInspectionAppointmentSystem.Business.Common.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CenterBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;

namespace VehicleInspectionAppointmentSystem.Business.Services.CenterBusiness;

public class CenterService : ICenterService
{
    private readonly IUnitOfWork _unitOfWork;

    public CenterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CanAddTimeSlotForDayAsync(int centerId, DateTime timeSlotDate)
    {
        var result = await _unitOfWork.CenterRepository.CanAddTimeSlotForDayAsync(centerId, timeSlotDate);

        if (!result)
            throw new ConflictException("Today's capacity of this technical examination is full");

        return result;
    }

    public async Task<List<CenterResponseDto>> GetActiveCentersOfCityAsync(int cityId)
    {
        var availableCityCenters = await _unitOfWork.CenterRepository.GetActiveCentersOfCityAsync(cityId);

        if (availableCityCenters == null || !availableCityCenters.Any())
            throw new NotFoundException("We do not have any available centers in this city");

        return availableCityCenters;
    }
}
