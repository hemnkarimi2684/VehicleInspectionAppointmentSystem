using Microsoft.EntityFrameworkCore;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.VehicleRepo;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<VehicleResponseDto>> GetUserVehiclesAsync(int userId)
    {
        return await Entities
                          .AsNoTracking()
                          .Where(v => v.UserId == userId && v.IsActive)
                          .Select(v => new VehicleResponseDto
                          (
                              v.Id,
                              v.Name,
                              v.Vin,
                              v.Plate,
                              v.FuelType.ToString(),
                              v.ProductionYear
                          ))
                          .ToListAsync();
    }

    public async Task<bool> IsCarOwnedByUserAsync(int vehicleId, int userId) => await AnyAsync(v => v.Id == vehicleId && v.UserId == userId && v.IsActive);

    public async Task<bool> IsVehicleExistAsync(int vehicleId) => await AnyAsync(v => v.Id == vehicleId && v.IsActive);

}
