using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.VehicleBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Services.VehicleBusiness;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<VehicleResponseDto> GetByIdAsync(int id, bool tracking = false)
    {
        var foundedVehicle = await _vehicleRepository.GetByIdAsync(id, tracking);

        if (foundedVehicle == null || !foundedVehicle.IsActive)
            throw new NotFoundException("the vehicle not exist in system!");

        return new VehicleResponseDto(foundedVehicle.Id, foundedVehicle.Name, foundedVehicle.Vin, foundedVehicle.Plate,
                              foundedVehicle.FuelType.ToString(), foundedVehicle.ProductionYear);
    }

    public async Task<List<VehicleResponseDto>> GetUserVehiclesAsync(int userId)
    {
        var vehicles = await _vehicleRepository.GetUserVehiclesAsync(userId);

        if (vehicles == null || !vehicles.Any())
            throw new NotFoundException("Dear user you dont have any vehicle in the system!");

        return vehicles;
    }

    public async Task<bool> IsCarOwnedByUserAsync(int vehicleId, int userId)
    {
        var result = await _vehicleRepository.IsCarOwnedByUserAsync(vehicleId, userId);

        if (!result)
            throw new ForbiddenException("Dear user, this car does not belong to you");

        return result;
    }

    public async Task<bool> IsVehicleExistAsync(int vehicleId)
    {
        var result = await _vehicleRepository.IsVehicleExistAsync(vehicleId);

        if (!result)
            throw new NotFoundException("the vehicle not exist in the system!");

        return result;
    }
}
